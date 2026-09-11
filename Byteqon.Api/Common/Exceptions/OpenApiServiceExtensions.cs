using Byteqon.Api.OpenApi;

namespace Byteqon.Api.Extensions;

public static class OpenApiServiceExtensions
{
    public static IServiceCollection AddByteqonOpenApi(
        this IServiceCollection services)
    {
        services.AddOpenApi(
            OpenApiConstants.DocumentName,
            options =>
            {
                options.AddDocumentTransformer(
                    (document, context, cancellationToken) =>
                    {
                        document.Info.Title =
                            OpenApiConstants.ApiTitle;

                        document.Info.Version =
                            OpenApiConstants.ApiVersion;

                        document.Info.Description =
                            OpenApiConstants.ApiDescription;

                        return Task.CompletedTask;
                    });
            });

        return services;
    }
}

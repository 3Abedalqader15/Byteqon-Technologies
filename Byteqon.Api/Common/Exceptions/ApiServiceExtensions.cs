using Byteqon.Api.Common.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.Extensions;

public static class ApiServiceExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<ValidateModelAttribute>();
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddProblemDetails(options =>
        {
            options.CustomizeProblemDetails = context =>
            {
                HttpContext httpContext =
                    context.HttpContext;

                context.ProblemDetails.Instance ??=
                    httpContext.Request.Path;

                context.ProblemDetails.Extensions.TryAdd(
                    "traceId",
                    httpContext.TraceIdentifier);
            };
        });

        services.AddByteqonOpenApi();

        services.AddByteqonHealthChecks();

        return services;
    }
}

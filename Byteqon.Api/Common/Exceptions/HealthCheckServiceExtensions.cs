using Byteqon.Api.HealthChecks;

namespace Byteqon.Api.Extensions;

public static class HealthCheckServiceExtensions
{
    public static IServiceCollection AddByteqonHealthChecks(
        this IServiceCollection services)
    {
        services
            .AddHealthChecks()
            .AddCheck<SelfHealthCheck>(
                HealthCheckConstants.SelfCheckName,
                tags:
                [
                    HealthCheckConstants.LiveTag,
                    HealthCheckConstants.ReadyTag
                ]);

        return services;
    }
}

using Byteqon.Api.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Byteqon.Api.Extensions;

public static class HealthCheckEndpointExtensions
{
    public static IEndpointRouteBuilder MapByteqonHealthChecks(
        this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapHealthChecks(
            HealthCheckConstants.LiveEndpoint,
            new HealthCheckOptions
            {
                Predicate = registration =>
                    registration.Tags.Contains(
                        HealthCheckConstants.LiveTag),

                ResponseWriter =
                    HealthCheckResponseWriter.WriteResponseAsync
            })
            .AllowAnonymous();

        endpoints.MapHealthChecks(
            HealthCheckConstants.ReadyEndpoint,
            new HealthCheckOptions
            {
                Predicate = registration =>
                    registration.Tags.Contains(
                        HealthCheckConstants.ReadyTag),

                ResponseWriter =
                    HealthCheckResponseWriter.WriteResponseAsync
            })
            .AllowAnonymous();

        return endpoints;
    }
}

using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Byteqon.Api.HealthChecks;

public sealed class SelfHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        return Task.FromResult(
            HealthCheckResult.Healthy(
                "BYTEQON API is running."));
    }
}

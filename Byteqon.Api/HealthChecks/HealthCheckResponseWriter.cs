using System.Text.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Byteqon.Api.HealthChecks;

public static class HealthCheckResponseWriter
{
    public static async Task WriteResponseAsync(
        HttpContext httpContext,
        HealthReport healthReport)
    {
        httpContext.Response.ContentType =
            "application/json";

        var response = new
        {
            status = healthReport.Status.ToString(),
            duration = healthReport.TotalDuration.TotalMilliseconds,
            checks = healthReport.Entries.Select(entry => new
            {
                name = entry.Key,
                status = entry.Value.Status.ToString(),
                description = entry.Value.Description,
                duration =
                    entry.Value.Duration.TotalMilliseconds
            })
        };

        await JsonSerializer.SerializeAsync(
            httpContext.Response.Body,
            response,
            cancellationToken:
                httpContext.RequestAborted);
    }
}

namespace Byteqon.Api.HealthChecks;

public static class HealthCheckConstants
{
    public const string LiveEndpoint =
        "/health/live";

    public const string ReadyEndpoint =
        "/health/ready";

    public const string LiveTag =
        "live";

    public const string ReadyTag =
        "ready";

    public const string SelfCheckName =
        "self";
}

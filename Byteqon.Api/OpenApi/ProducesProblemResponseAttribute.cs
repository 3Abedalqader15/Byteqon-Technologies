using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.OpenApi;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true)]
public sealed class ProducesProblemResponseAttribute
    : ProducesResponseTypeAttribute
{
    public ProducesProblemResponseAttribute(
        int statusCode)
        : base(
            typeof(ProblemDetails),
            statusCode,
            OpenApiConstants.ProblemContentType)
    {
    }
}

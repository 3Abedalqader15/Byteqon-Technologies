using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.OpenApi;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = true,
    Inherited = true)]
public sealed class ProducesValidationProblemResponseAttribute
    : ProducesResponseTypeAttribute
{
    public ProducesValidationProblemResponseAttribute()
        : base(
            typeof(ValidationProblemDetails),
            StatusCodes.Status400BadRequest,
            OpenApiConstants.ProblemContentType)
    {
    }
}

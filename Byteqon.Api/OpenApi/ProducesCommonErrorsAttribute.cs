using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Byteqon.Api.OpenApi;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Method,
    AllowMultiple = false,
    Inherited = true)]
public sealed class ProducesCommonErrorsAttribute
    : Attribute,
      IApiResponseMetadataProvider
{
    public void SetContentTypes(
        MediaTypeCollection contentTypes)
    {
        contentTypes.Add(
            OpenApiConstants.ProblemContentType);
    }

    public IReadOnlyList<string> ContentTypes =>
        [OpenApiConstants.ProblemContentType];

    public string? Description =>
        "A standardized ProblemDetails error response.";

    public int StatusCode =>
        StatusCodes.Status500InternalServerError;

    public Type? Type =>
        typeof(ProblemDetails);
}

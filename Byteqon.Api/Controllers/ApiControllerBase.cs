using Byteqon.Api.Common.Extensions;
using Byteqon.Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult HandleFailure(Result result)
    {
        return result.ToProblemDetails(HttpContext);
    }

    protected IActionResult HandleResult<TValue>(
        Result<TValue> result)
    {
        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return Ok(result.Value);
    }

    protected IActionResult HandleCreatedResult<TValue>(
        Result<TValue> result,
        string actionName,
        object routeValues)
    {
        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            actionName,
            routeValues,
            result.Value);
    }

    protected IActionResult HandleNoContentResult(
        Result result)
    {
        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return NoContent();
    }
}

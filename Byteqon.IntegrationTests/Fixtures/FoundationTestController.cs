using System.ComponentModel.DataAnnotations;
using Byteqon.Api.Controllers;
using Byteqon.Application.Common.Results;
using Byteqon.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Byteqon.IntegrationTests.Fixtures;

[Route("_tests/foundation")]
public sealed class FoundationTestController : ApiControllerBase
{
    [HttpPost("validation")]
    public IActionResult ValidateRequest(
        FoundationValidationRequest request)
    {
        return Ok(request);
    }

    [HttpGet("domain-exception")]
    public IActionResult ThrowDomainException()
    {
        throw new DomainException(
            "The operation violates a domain rule.");
    }

    [HttpGet("unexpected-exception")]
    public IActionResult ThrowUnexpectedException()
    {
        throw new InvalidOperationException(
            "This sensitive technical message must not reach the client.");
    }

    [HttpGet("not-found-result")]
    public IActionResult ReturnNotFoundResult()
    {
        Result<string> result =
            Result.Failure<string>(
                Error.NotFound(
                    "Foundation.NotFound",
                    "The requested foundation resource was not found."));

        return HandleResult(result);
    }
}

public sealed record FoundationValidationRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Email must be valid.")]
    public string? Email { get; init; }
}

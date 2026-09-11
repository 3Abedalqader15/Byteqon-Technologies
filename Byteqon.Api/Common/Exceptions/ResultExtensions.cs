using Byteqon.Application.Common.Results;
using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.Common.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToProblemDetails(
        this Result result,
        HttpContext httpContext)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException(
                "A successful result cannot be converted to ProblemDetails.");
        }

        Error error = result.Error;
        int statusCode = MapStatusCode(error.Type);

        ProblemDetails problemDetails = new()
        {
            Type = CreateProblemType(error.Type),
            Title = CreateTitle(error.Type),
            Status = statusCode,
            Detail = error.Message,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions["errorCode"] =
            error.Code;

        problemDetails.Extensions["traceId"] =
            httpContext.TraceIdentifier;

        return new ObjectResult(problemDetails)
        {
            StatusCode = statusCode,
            ContentTypes =
            {
                "application/problem+json"
            }
        };
    }

    private static int MapStatusCode(ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation =>
                StatusCodes.Status400BadRequest,

            ErrorType.Unauthorized =>
                StatusCodes.Status401Unauthorized,

            ErrorType.Forbidden =>
                StatusCodes.Status403Forbidden,

            ErrorType.NotFound =>
                StatusCodes.Status404NotFound,

            ErrorType.Conflict =>
                StatusCodes.Status409Conflict,

            ErrorType.Failure =>
                StatusCodes.Status500InternalServerError,

            ErrorType.None =>
                throw new InvalidOperationException(
                    "ErrorType.None cannot be mapped to an error response."),

            _ =>
                StatusCodes.Status500InternalServerError
        };
    }

    private static string CreateTitle(
        ErrorType errorType)
    {
        return errorType switch
        {
            ErrorType.Validation =>
                "Validation failed",

            ErrorType.Unauthorized =>
                "Authentication required",

            ErrorType.Forbidden =>
                "Access forbidden",

            ErrorType.NotFound =>
                "Resource not found",

            ErrorType.Conflict =>
                "A conflict occurred",

            ErrorType.Failure =>
                "Operation failed",

            _ =>
                "An unexpected error occurred"
        };
    }

    private static string CreateProblemType(
        ErrorType errorType)
    {
        string errorName = errorType switch
        {
            ErrorType.Validation => "validation",
            ErrorType.Unauthorized => "unauthorized",
            ErrorType.Forbidden => "forbidden",
            ErrorType.NotFound => "not-found",
            ErrorType.Conflict => "conflict",
            ErrorType.Failure => "failure",

            ErrorType.None =>
                throw new InvalidOperationException(
                    "ErrorType.None cannot be mapped to an error response."),

            _ => "internal-server-error"
        };

        return $"https://api.byteqon.com/errors/{errorName}";
    }
}

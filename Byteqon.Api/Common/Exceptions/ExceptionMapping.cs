using Byteqon.Application.Common.Exceptions;
using Byteqon.Domain.Common.Exceptions;

namespace Byteqon.Api.Common.Exceptions;

internal static class ExceptionMapping
{
    internal static ExceptionDescriptor Map(Exception exception)
    {
        return exception switch
        {
            DomainException domainException =>
                new ExceptionDescriptor(
                    StatusCodes.Status422UnprocessableEntity,
                    "Domain rule violation",
                    domainException.Message,
                    "domain-rule-violation"),

            ConflictException conflictException =>
                new ExceptionDescriptor(
                    StatusCodes.Status409Conflict,
                    "A conflict occurred",
                    conflictException.Message,
                    "conflict"),

            BadHttpRequestException =>
                new ExceptionDescriptor(
                    StatusCodes.Status400BadRequest,
                    "Invalid request",
                    "The request is invalid or malformed.",
                    "invalid-request"),

            UnauthorizedAccessException =>
                new ExceptionDescriptor(
                    StatusCodes.Status403Forbidden,
                    "Access forbidden",
                    "You do not have permission to perform this action.",
                    "forbidden"),

            TimeoutException =>
                new ExceptionDescriptor(
                    StatusCodes.Status504GatewayTimeout,
                    "Operation timed out",
                    "The operation did not complete within the allowed time.",
                    "operation-timeout"),

            OperationCanceledException =>
                new ExceptionDescriptor(
                    StatusCodes.Status408RequestTimeout,
                    "Request cancelled",
                    "The request was cancelled before it completed.",
                    "request-cancelled"),

            _ =>
                new ExceptionDescriptor(
                    StatusCodes.Status500InternalServerError,
                    "An unexpected error occurred",
                    "The server encountered an unexpected error.",
                    "internal-server-error")
        };
    }
}

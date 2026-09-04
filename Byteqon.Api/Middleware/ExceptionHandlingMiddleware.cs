using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.Middleware;

public sealed class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(
        HttpContext context,
        IProblemDetailsService problemDetailsService)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException)
            when (context.RequestAborted.IsCancellationRequested)
        {
            _logger.LogInformation(
                "Request was cancelled by the client. TraceId: {TraceId}",
                context.TraceIdentifier);

            throw;
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(
                context,
                exception,
                problemDetailsService);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception,
        IProblemDetailsService problemDetailsService)
    {
        _logger.LogError(
            exception,
            "An unhandled exception occurred while processing {Method} {Path}. TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path,
            context.TraceIdentifier);

        if (context.Response.HasStarted)
        {
            _logger.LogWarning(
                "The response has already started. Exception handling response cannot be written. TraceId: {TraceId}",
                context.TraceIdentifier);

            throw exception;
        }

        context.Response.Clear();
        context.Response.StatusCode =
            StatusCodes.Status500InternalServerError;

        var problemDetails = new ProblemDetails
        {
            Type = "https://api.byteqon.com/errors/internal-server-error",
            Title = "Internal server error",
            Status = StatusCodes.Status500InternalServerError,
            Detail = "An unexpected error occurred while processing the request.",
            Instance = context.Request.Path
        };

        problemDetails.Extensions["traceId"] =
            context.TraceIdentifier;

        await problemDetailsService.WriteAsync(
            new ProblemDetailsContext
            {
                HttpContext = context,
                ProblemDetails = problemDetails
            });
    }
}

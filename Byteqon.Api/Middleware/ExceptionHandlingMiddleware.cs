using Byteqon.Api.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Byteqon.Api.Middleware;

public sealed class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger,
    IProblemDetailsService problemDetailsService)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException)
            when (context.RequestAborted.IsCancellationRequested)
        {
            logger.LogInformation(
                "The request was cancelled by the client. TraceId: {TraceId}",
                context.TraceIdentifier);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        ExceptionDescriptor descriptor =
            ExceptionMapping.Map(exception);

        LogException(
            exception,
            descriptor.StatusCode,
            context.TraceIdentifier);

        if (context.Response.HasStarted)
        {
            logger.LogWarning(
                "The response has already started. " +
                "ProblemDetails cannot be written. TraceId: {TraceId}",
                context.TraceIdentifier);

            throw exception;
        }

        context.Response.Clear();
        context.Response.StatusCode = descriptor.StatusCode;

        ProblemDetails problemDetails = new()
        {
            Type =
                $"https://api.byteqon.com/errors/{descriptor.ErrorCode}",
            Title = descriptor.Title,
            Status = descriptor.StatusCode,
            Detail = descriptor.Detail,
            Instance = context.Request.Path
        };

        problemDetails.Extensions["traceId"] =
            context.TraceIdentifier;

        problemDetails.Extensions["errorCode"] =
            descriptor.ErrorCode;

        ProblemDetailsContext problemDetailsContext = new()
        {
            HttpContext = context,
            ProblemDetails = problemDetails,
            Exception = exception
        };

        bool wasWritten =
            await problemDetailsService.TryWriteAsync(
                problemDetailsContext);

        if (!wasWritten)
        {
            context.Response.ContentType =
                "application/problem+json";

            await context.Response.WriteAsJsonAsync(
                problemDetails,
                cancellationToken: context.RequestAborted);
        }
    }

    private void LogException(
        Exception exception,
        int statusCode,
        string traceId)
    {
        if (statusCode >= StatusCodes.Status500InternalServerError)
        {
            logger.LogError(
                exception,
                "An unhandled server exception occurred. " +
                "StatusCode: {StatusCode}, TraceId: {TraceId}",
                statusCode,
                traceId);

            return;
        }

        logger.LogWarning(
            exception,
            "A handled application exception occurred. " +
            "StatusCode: {StatusCode}, TraceId: {TraceId}",
            statusCode,
            traceId);
    }
}

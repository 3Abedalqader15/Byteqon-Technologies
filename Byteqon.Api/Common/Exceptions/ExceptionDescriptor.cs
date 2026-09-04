namespace Byteqon.Api.Common.Exceptions;

internal sealed record ExceptionDescriptor(
    int StatusCode,
    string Title,
    string Detail,
    string ErrorCode);

namespace Byteqon.Application.Common.Exceptions;

public sealed class ConflictException : ByteqonApplicationException
{
    public ConflictException(string message)
        : base(message)
    {
    }

    public ConflictException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}

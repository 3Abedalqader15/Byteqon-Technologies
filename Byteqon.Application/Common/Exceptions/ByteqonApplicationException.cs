namespace Byteqon.Application.Common.Exceptions;

public abstract class ByteqonApplicationException : Exception
{
    protected ByteqonApplicationException(string message)
        : base(message)
    {
    }

    protected ByteqonApplicationException(
        string message,
        Exception innerException)
        : base(message, innerException)
    {
    }
}

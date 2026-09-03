namespace Byteqon.Application.Common.Results;

public class Result
{
    protected Result(
        bool isSuccess,
        Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException(
                "A successful result cannot contain an error.");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException(
                "A failed result must contain an error.");
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success()
    {
        return new Result(
            true,
            Error.None);
    }

    public static Result Failure(
        Error error)
    {
        return new Result(
            false,
            error);
    }

    public static Result<TValue> Success<TValue>(
        TValue value)
    {
        return new Result<TValue>(
            value,
            true,
            Error.None);
    }

    public static Result<TValue> Failure<TValue>(
        Error error)
    {
        return new Result<TValue>(
            default,
            false,
            error);
    }
}

public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    internal Result(
        TValue? value,
        bool isSuccess,
        Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException(
                    "The value of a failed result cannot be accessed.");
            }

            return _value!;
        }
    }
}
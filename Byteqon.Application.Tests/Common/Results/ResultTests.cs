using Byteqon.Application.Common.Results;

namespace Byteqon.Application.Tests.Common.Results;

public sealed class ResultTests
{
    [Fact]
    public void Success_Should_Create_Successful_Result()
    {
        var result = Result.Success();

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Failure_Should_Create_Failed_Result()
    {
        var error = Error.NotFound(
            "Services.NotFound",
            "The requested service was not found.");

        var result = Result.Failure(error);

        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(error, result.Error);
    }

    [Fact]
    public void GenericSuccess_Should_Return_Value()
    {
        var result = Result.Success("BYTEQON");

        Assert.True(result.IsSuccess);
        Assert.Equal("BYTEQON", result.Value);
    }

    [Fact]
    public void Accessing_Value_Of_Failed_Result_Should_Throw()
    {
        var result = Result.Failure<string>(
            Error.NotFound(
                "Services.NotFound",
                "The requested service was not found."));

        var action = () => result.Value;

        Assert.Throws<InvalidOperationException>(action);
    }
}

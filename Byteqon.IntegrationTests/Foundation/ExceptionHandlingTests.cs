using System.Net;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Http;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class ExceptionHandlingTests
{
    private readonly HttpClient _client;

    public ExceptionHandlingTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Domain_exception_should_return_422_problem_details()
    {
        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(
                "/_tests/foundation/domain-exception");

        // Assert
        Assert.Equal(
            HttpStatusCode.UnprocessableEntity,
            response.StatusCode);

        using JsonDocument json =
            await response.ReadJsonAsync();

        JsonElement root = json.RootElement;

        Assert.Equal(
            StatusCodes.Status422UnprocessableEntity,
            root.GetProperty("status").GetInt32());

        Assert.Equal(
            "domain-rule-violation",
            root.GetProperty("errorCode").GetString());

        Assert.Equal(
            "The operation violates a domain rule.",
            root.GetProperty("detail").GetString());
    }

    [Fact]
    public async Task Unexpected_exception_should_return_safe_500_response()
    {
        // Arrange
        const string sensitiveMessage =
            "This sensitive technical message must not reach the client.";

        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(
                "/_tests/foundation/unexpected-exception");

        // Assert
        Assert.Equal(
            HttpStatusCode.InternalServerError,
            response.StatusCode);

        string responseBody =
            await response.Content.ReadAsStringAsync();

        Assert.DoesNotContain(
            sensitiveMessage,
            responseBody,
            StringComparison.Ordinal);

        Assert.DoesNotContain(
            "InvalidOperationException",
            responseBody,
            StringComparison.Ordinal);

        Assert.DoesNotContain(
            "StackTrace",
            responseBody,
            StringComparison.OrdinalIgnoreCase);

        using JsonDocument json =
            JsonDocument.Parse(responseBody);

        JsonElement root = json.RootElement;

        Assert.Equal(
            StatusCodes.Status500InternalServerError,
            root.GetProperty("status").GetInt32());

        Assert.False(
            string.IsNullOrWhiteSpace(
                root.GetProperty("traceId").GetString()));
    }
}

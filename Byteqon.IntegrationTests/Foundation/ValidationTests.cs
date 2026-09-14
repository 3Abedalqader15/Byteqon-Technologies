using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Http;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class ValidationTests
{
    private readonly HttpClient _client;

    public ValidationTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Invalid_request_should_return_validation_problem_details()
    {
        // Arrange
        var request = new
        {
            name = "",
            email = "invalid-email"
        };

        // Act
        using HttpResponseMessage response =
            await _client.PostAsJsonAsync(
                "/_tests/foundation/validation",
                request);

        // Assert
        Assert.Equal(
            HttpStatusCode.BadRequest,
            response.StatusCode);

        Assert.Equal(
            "application/problem+json",
            response.Content.Headers.ContentType?.MediaType);

        using JsonDocument json =
            await response.ReadJsonAsync();

        JsonElement root = json.RootElement;

        Assert.Equal(
            StatusCodes.Status400BadRequest,
            root.GetProperty("status").GetInt32());

        Assert.Equal(
            "validation",
            root.GetProperty("errorCode").GetString());

        Assert.True(
            root.TryGetProperty(
                "errors",
                out JsonElement errors));

        Assert.True(
            errors.TryGetProperty(
                "Email",
                out _));

        Assert.False(
            string.IsNullOrWhiteSpace(
                root.GetProperty("traceId").GetString()));
    }

    [Fact]
    public async Task Valid_request_should_reach_controller()
    {
        // Arrange
        var request = new
        {
            name = "BYTEQON",
            email = "contact@byteqon.com"
        };

        // Act
        using HttpResponseMessage response =
            await _client.PostAsJsonAsync(
                "/_tests/foundation/validation",
                request);

        // Assert
        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);
    }
}

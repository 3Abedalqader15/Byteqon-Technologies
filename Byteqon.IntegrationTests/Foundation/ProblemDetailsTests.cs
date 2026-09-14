using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Http;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class ProblemDetailsTests
{
    private readonly HttpClient _client;

    public ProblemDetailsTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Unknown_route_should_return_404_problem_details()
    {
        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(
                "/api/route-that-does-not-exist");

        // Assert
        Assert.Equal(
            HttpStatusCode.NotFound,
            response.StatusCode);

        Assert.Equal(
            "application/problem+json",
            response.Content.Headers.ContentType?.MediaType);

        using JsonDocument json =
            await response.ReadJsonAsync();

        JsonElement root = json.RootElement;

        Assert.Equal(
            StatusCodes.Status404NotFound,
            root.GetProperty("status").GetInt32());

        Assert.Equal(
            "/api/route-that-does-not-exist",
            root.GetProperty("instance").GetString());

        Assert.False(
            string.IsNullOrWhiteSpace(
                root.GetProperty("traceId").GetString()));
    }
}

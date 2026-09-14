using System.Net;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Http;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class ResultMappingTests
{
    private readonly HttpClient _client;

    public ResultMappingTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Not_found_result_should_return_404_problem_details()
    {
        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(
                "/_tests/foundation/not-found-result");

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
            "Foundation.NotFound",
            root.GetProperty("errorCode").GetString());

        Assert.Equal(
            "The requested foundation resource was not found.",
            root.GetProperty("detail").GetString());

        Assert.False(
            string.IsNullOrWhiteSpace(
                root.GetProperty("traceId").GetString()));
    }
}

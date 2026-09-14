using System.Net;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class OpenApiTests
{
    private readonly HttpClient _client;

    public OpenApiTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task OpenApi_document_should_be_available_in_development()
    {
        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(
                "/openapi/v1.json");

        // Assert
        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);

        using JsonDocument json =
            await response.ReadJsonAsync();

        JsonElement root = json.RootElement;

        Assert.True(
            root.TryGetProperty(
                "openapi",
                out _));

        JsonElement info =
            root.GetProperty("info");

        Assert.Equal(
            "BYTEQON Technologies API",
            info.GetProperty("title").GetString());

        Assert.Equal(
            "v1",
            info.GetProperty("version").GetString());

        Assert.True(
            root.TryGetProperty(
                "paths",
                out _));
    }
}

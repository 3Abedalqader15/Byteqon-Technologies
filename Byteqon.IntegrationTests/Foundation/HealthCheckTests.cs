using System.Net;
using System.Text.Json;
using Byteqon.IntegrationTests.Fixtures;
using Byteqon.IntegrationTests.Helpers;

namespace Byteqon.IntegrationTests.Foundation;

[Collection(IntegrationTestCollection.Name)]
public sealed class HealthCheckTests
{
    private readonly HttpClient _client;

    public HealthCheckTests(
        ByteqonWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData("/health/live")]
    [InlineData("/health/ready")]
    public async Task Health_endpoint_should_return_healthy_response(
        string endpoint)
    {
        // Act
        using HttpResponseMessage response =
            await _client.GetAsync(endpoint);

        // Assert
        Assert.Equal(
            HttpStatusCode.OK,
            response.StatusCode);

        Assert.Equal(
            "application/json",
            response.Content.Headers.ContentType?.MediaType);

        using JsonDocument json =
            await response.ReadJsonAsync();

        JsonElement root = json.RootElement;

        Assert.Equal(
            "Healthy",
            root.GetProperty("status").GetString());

        Assert.True(
            root.TryGetProperty(
                "checks",
                out JsonElement checks));

        Assert.Equal(
            JsonValueKind.Array,
            checks.ValueKind);

        Assert.Contains(
            checks.EnumerateArray(),
            check =>
                check.GetProperty("name").GetString() ==
                "self");
    }
}

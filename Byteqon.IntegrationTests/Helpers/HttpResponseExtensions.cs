using System.Text.Json;

namespace Byteqon.IntegrationTests.Helpers;

internal static class HttpResponseExtensions
{
    internal static async Task<JsonDocument> ReadJsonAsync(
        this HttpResponseMessage response)
    {
        Stream contentStream =
            await response.Content.ReadAsStreamAsync();

        return await JsonDocument.ParseAsync(
            contentStream);
    }
}

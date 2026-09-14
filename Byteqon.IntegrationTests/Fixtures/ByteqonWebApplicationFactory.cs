using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Byteqon.IntegrationTests.Fixtures;

public sealed class ByteqonWebApplicationFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(
        IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");

        builder.ConfigureServices(services =>
        {
            IMvcBuilder mvcBuilder =
                services.AddControllers();

            mvcBuilder.PartManager.ApplicationParts.Add(
                new AssemblyPart(
                    typeof(FoundationTestController).Assembly));
        });
    }
}

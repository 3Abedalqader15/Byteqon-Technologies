using Byteqon.Api.Extensions;
using Byteqon.Api.Middleware;
using Byteqon.Api.OpenApi;
using Byteqon.Application;
using Byteqon.Infrastructure;

WebApplicationBuilder builder =
    WebApplication.CreateBuilder(args);

builder.Services.AddApiServices();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(
    builder.Configuration);

WebApplication app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(
        OpenApiConstants.JsonRoute);
}


app.UseStatusCodePages();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapByteqonHealthChecks();

app.Run();

public partial class Program;

using Byteqon.Api.Common.Filters;
using Byteqon.Api.Extensions;
using Byteqon.Api.Middleware;
using Byteqon.Api.OpenApi;
using Microsoft.AspNetCore.Mvc;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// problem details configuration
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance ??=
            context.HttpContext.Request.Path;

        context.ProblemDetails.Extensions.TryAdd(
            "traceId",
            context.HttpContext.TraceIdentifier);
    };
});



// Add OpenAPI services
builder.Services.AddByteqonOpenApi();

// Add health checks
builder.Services.AddByteqonHealthChecks();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(OpenApiConstants.JsonRoute);
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseStatusCodePages();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Map health check endpoints
app.MapByteqonHealthChecks();

app.Run();

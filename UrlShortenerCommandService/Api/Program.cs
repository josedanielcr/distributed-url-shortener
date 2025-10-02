using Api.Common;
using Api.Extensions;
using Carter;

var builder = WebApplication.CreateBuilder(args);
const string settingsSectionName = "Settings";

builder.Services.AddOpenApi();

builder.Configuration
#if DEBUG
    .AddUserSecrets<Program>(optional: true)
#endif
    .AddEnvironmentVariables();
builder.Services.Configure<Settings>(
    builder.Configuration.GetSection(settingsSectionName));
var configuration = builder.Configuration;

builder.Services.AddApplicationServices();
builder.Services.AddApplicationDb(configuration);
builder.Services.AddCarter();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapCarter();
app.Run();
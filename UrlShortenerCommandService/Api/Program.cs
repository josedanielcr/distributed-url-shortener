using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
var configuration = builder.Configuration;
builder.Services.AddApplicationServices();
builder.Services.AddApplicationDb(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
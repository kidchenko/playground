using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var movieApiKey = builder.Configuration["Movies__ServiceApiKey"];

var app = builder.Build();

app.MapGet("/", () => movieApiKey);

app.Run();

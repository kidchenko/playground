using Chaos.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGithubRepository, GithubRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/repos", async (IGithubRepository githubRepository) => await githubRepository.Get());

app.Run();

using Chaos.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddScoped<IGithubRepository, GithubRepository>();

var app = builder.Build();
var random = new Random();

app.MapGet("/", () => "Hello World!");

app.MapGet("/repos", async (IGithubRepository githubRepository) =>
{
    var next = random.Next(1, 10);
    if (next <= 6)
    {
        throw new Exception();
    }
    return await githubRepository.Get();
});

app.Run();

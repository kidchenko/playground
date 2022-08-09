using Chaos.Domain;
using Polly.Contrib.Simmy;

var faultPolicy = MonkeyPolicy.InjectFaultAsync<HttpResponseMessage>(
    new HttpRequestException("Simmy threw an exception"),
    injectionRate: .90,
    enabled: () => true
);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("GithubClient")
    .AddPolicyHandler(faultPolicy);
builder.Services.AddScoped<IGithubRepository, GithubRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/repos", async (IGithubRepository githubRepository) => await githubRepository.Get());

app.Run();

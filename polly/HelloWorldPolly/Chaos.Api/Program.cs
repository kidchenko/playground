using Chaos.Domain;
using Polly.Contrib.Simmy;
using Polly.Contrib.Simmy.Outcomes;

AsyncInjectOutcomePolicy<HttpResponseMessage> faultPolicy = MonkeyPolicy.InjectFaultAsync<HttpResponseMessage>(
    new HttpRequestException("Simmy threw an exception"),
    injectionRate: .7,
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

// See https://aka.ms/new-console-template for more information

using Chaos.Domain;
using HelloWorldPolly;
using Microsoft.Extensions.DependencyInjection;

await using var provider = new ServiceCollection()
    .AddHttpClient<GithubRepositoryChaosApiClient>()
    .Services
    .AddScoped<IGithubRepository, GithubRepositoryChaosApiClient>()
    .BuildServiceProvider();

using var scope = provider.CreateScope();

var githubRepository = scope.ServiceProvider.GetRequiredService<IGithubRepository>();

var repositories = await githubRepository.Get();

foreach (var repository in repositories)
{
    Console.WriteLine(repository);
}

Console.WriteLine("Program finished");

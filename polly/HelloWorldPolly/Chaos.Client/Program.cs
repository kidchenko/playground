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

while (true)
{
    try
    {
        var repositories = await githubRepository.Get();

        foreach (var repository in repositories)
        {
            Console.WriteLine(repository);
        }
        Console.WriteLine();
    }
    catch (Exception e)
    {
        Console.WriteLine("API call failed!");
        Console.WriteLine(e);
        Console.WriteLine();
    }
    finally
    {
        Console.WriteLine("Waiting 3 seconds:");

        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine(1);

        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine(2);

        await Task.Delay(TimeSpan.FromSeconds(1));
        Console.WriteLine(3);
        Console.WriteLine();
    }
}


Console.WriteLine("Program finished");

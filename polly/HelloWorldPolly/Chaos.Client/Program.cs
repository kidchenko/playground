// See https://aka.ms/new-console-template for more information

using Chaos.Domain;
using HelloWorldPolly;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

await using var provider = new ServiceCollection()
    .AddHttpClient("ApiClient" )
    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(2),
        TimeSpan.FromSeconds(3)
    }, onRetry: (outcome, timespan, retryAttempt, context) =>
        {
            Console.WriteLine($"Delaying for {timespan.TotalMilliseconds}ms, then making retry {retryAttempt}.");
        }
    ))
    .AddTransientHttpErrorPolicy(builder => builder.CircuitBreakerAsync(
        handledEventsAllowedBeforeBreaking: 10,
        durationOfBreak: TimeSpan.FromSeconds(30)
    ))
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
        Console.WriteLine("Waiting 10 seconds:");

        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine(5);

        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine(10);

        Console.WriteLine();
    }
}

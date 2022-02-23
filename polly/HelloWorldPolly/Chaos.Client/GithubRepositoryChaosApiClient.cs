using System.Net.Http.Headers;
using System.Net.Http.Json;
using Chaos.Domain;

namespace HelloWorldPolly;

public class GithubRepositoryChaosApiClient : IGithubRepository
{
    private readonly HttpClient _httpClient;

    public GithubRepositoryChaosApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");

        _httpClient.BaseAddress = new Uri("https://localhost:7010");
    }

    public async Task<IReadOnlyCollection<Repository>> Get()
    {
        var repos = await _httpClient.GetFromJsonAsync<IEnumerable<Repository>>("/repos");

        if (repos is null)
        {
            throw new Exception("GithubRepository Error. Fail to call `/repos`");
        }

        return repos.ToList().AsReadOnly();
    }
}

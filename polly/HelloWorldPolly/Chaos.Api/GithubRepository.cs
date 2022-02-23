using System.Net.Http.Headers;
using Chaos.Domain;

public class GithubRepository : IGithubRepository
{
    private readonly HttpClient _httpClient;

    public GithubRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("GithubClient");
        // // these lines do the same as the line bellow, just a different syntax
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        // another way to add headers
        _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

        _httpClient.BaseAddress = new Uri("https://api.github.com/");
    }

    public async Task<IReadOnlyCollection<Repository>> Get()
    {
        var repos = await _httpClient.GetFromJsonAsync<IEnumerable<Repository>>("/orgs/dotnet/repos");

        if (repos is null)
        {
            throw new Exception("GithubRepository Error. Fail to call `/orgs/dotnet/repos`");
        }

        return repos.ToList().AsReadOnly();
    }
}

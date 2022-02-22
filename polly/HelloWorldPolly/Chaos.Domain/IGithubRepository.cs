namespace Chaos.Domain;

public interface IGithubRepository
{
    Task<IReadOnlyCollection<Repository>> Get();
}

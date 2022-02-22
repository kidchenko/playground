namespace Chaos.Domain;

public class Repository
{
    public long Id { get; set; }

    public string Name { get; set; }

    public bool Private { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} - Name: {Name} - IsPrivate: {Private}";
    }
}

using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Entities;

public class Visitor : Entity<int>
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Company { get; init; }

}


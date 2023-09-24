using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Entities;

public class Company : Entity<int>
{
    public string? Name { get; set; }
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
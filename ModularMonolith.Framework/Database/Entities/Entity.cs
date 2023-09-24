namespace ModularMonolith.Framework.Database.Entities;

public abstract class Entity<TKey>
{
    public TKey Id { get; set; }
    public bool Deleted { get; set; }
    
    public bool IsNew => Id.Equals(default);
}

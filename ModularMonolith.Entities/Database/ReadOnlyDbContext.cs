using Microsoft.EntityFrameworkCore;
using ModularMonolith.Framework.Database.Entities;

namespace ModularMonolith.Entities.Database;

public class ReadOnlyDbContext : DbContext
{

    public override int SaveChanges() => throw new InvalidOperationException("This is a read-only context");
    public override int SaveChanges(bool b) => throw new InvalidOperationException("This is a read-only context");
    public override Task<int> SaveChangesAsync(CancellationToken token) => throw new InvalidOperationException("This is a read-only context");
    public override Task<int> SaveChangesAsync(bool b, CancellationToken token) => throw new InvalidOperationException("This is a read-only context");

    public ReadOnlyDbContext()
    {
        
    }
    public ReadOnlyDbContext(DbContextOptions<ReadOnlyDbContext> options) : base(options)
    {
        
    }
    
    public IQueryable<TEntity> DbSet<TEntity>() where TEntity : class => Set<TEntity>().AsNoTracking();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasQueryFilter(x=> !x.Deleted);
        modelBuilder.Entity<Employee>().HasQueryFilter(x=> !x.Deleted);
        modelBuilder.Entity<Visit>().HasQueryFilter(x=> !x.Deleted);
        modelBuilder.Entity<Visitor>().HasQueryFilter(x=> !x.Deleted);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MM_Demo;Integrated Security=true;");
        }
        base.OnConfiguring(optionsBuilder);
    }
}
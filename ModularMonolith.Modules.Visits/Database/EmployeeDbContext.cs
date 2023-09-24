using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;


namespace ModularMonolith.Modules.Visits.Database;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Visitor> Visitors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Visit>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Visitor>().HasQueryFilter(x => !x.Deleted);
        
        base.OnModelCreating(modelBuilder);
    }
}
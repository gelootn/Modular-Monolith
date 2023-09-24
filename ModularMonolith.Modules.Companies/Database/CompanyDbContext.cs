using Microsoft.EntityFrameworkCore;
using ModularMonolith.Entities;

namespace ModularMonolith.Modules.Companies.Database;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
        
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Employee>().HasQueryFilter(x => !x.Deleted);
        modelBuilder.Entity<Visit>().HasQueryFilter(x => !x.Deleted);
        base.OnModelCreating(modelBuilder);
    }
}
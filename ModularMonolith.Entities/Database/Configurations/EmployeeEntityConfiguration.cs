using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Entities.Database.Configurations;

public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employees",x=> x.IsTemporal())
            .HasQueryFilter(x=> !x.Deleted);
    }
}
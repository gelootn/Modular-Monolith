using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Entities.Database.Configurations;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder
            .ToTable("Companies", x=> x.IsTemporal())
            .HasQueryFilter(x=> !x.Deleted);
    }
}
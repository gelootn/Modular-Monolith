using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Entities.Database.Configurations;

public class VisitorEntityConfiguration : IEntityTypeConfiguration<Visitor>
{
    public void Configure(EntityTypeBuilder<Visitor> builder)
    {
        builder
            .ToTable("Visitors", x=> x.IsTemporal())
            .HasQueryFilter(x=> !x.Deleted);
    }
}
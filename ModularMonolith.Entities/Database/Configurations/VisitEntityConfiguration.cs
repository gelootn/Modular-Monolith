using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ModularMonolith.Entities.Database.Configurations;

public class VisitEntityConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable("Visits")
                 .HasQueryFilter(x=> !x.Deleted);
        
        builder
            .HasOne(x => x.Company)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(x => x.Visitor)
            .WithMany().OnDelete(DeleteBehavior.NoAction);
        builder
            .HasOne(x => x.Employee)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }
}
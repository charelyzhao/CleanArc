using CleanArc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArc.Infrastructure.Data.Configurations;

public class TestTableConfiguration : IEntityTypeConfiguration<TestTable>
{
    public void Configure(EntityTypeBuilder<TestTable> builder)
    {
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}

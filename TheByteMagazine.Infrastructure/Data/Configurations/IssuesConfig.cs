using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheByteMagazine.Infrastructure.Data.Configurations;

public class IssuesConfig : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.Property(i => i.Title)
            .HasMaxLength(50);

        builder.Property(i => i.Description)
            .HasMaxLength(100);

        builder.Property(i => i.CoverImageUrl)
            .HasMaxLength(150);

        builder.Property(i => i.DirectorNote)
            .HasMaxLength(500);

        builder.Property(i => i.FlipHtmlUrl)
            .HasMaxLength(350)
            .IsRequired(false);
    }
}

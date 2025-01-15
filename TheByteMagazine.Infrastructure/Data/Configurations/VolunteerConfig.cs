using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheByteMagazine.Infrastructure.Data.Configurations;

public class VolunteerConfig : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.Property(x => x.FirstName)
            .HasMaxLength(40);

        builder.Property(x => x.LastName)
            .HasMaxLength(40);

        builder.Property(x => x.PersonalImagePath)
            .HasMaxLength(150);

        builder.Property(x => x.LinkedInProfileUrl)
            .HasMaxLength(250);
    }
}

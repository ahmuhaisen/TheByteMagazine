using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheByteMagazine.Infrastructure.Data.Configurations;


public class RoleTypeConfig : IEntityTypeConfiguration<RoleType>
{
    public void Configure(EntityTypeBuilder<RoleType> builder)
    {
        builder.Property(x => x.Id)
            .HasColumnType("tinyint");

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.Property(x => x.Description)
            .HasMaxLength(100);

        builder.Property(x => x.isUnique)
            .HasDefaultValue(false);

        builder.HasData(Seed());
    }

    private RoleType[] Seed()
    {
        return new[] {
            new RoleType { Id = 1, Name = "Director", Description = "Oversees the entire publication process and team.", isUnique = true },
            new RoleType { Id = 2, Name = "EditorInChief", Description = "Responsible for the overall editorial direction and content quality.", isUnique = true },
            new RoleType { Id = 3, Name = "Designer", Description = "Creates the visual design and layout for the publication.", isUnique = false },
            new RoleType { Id = 4, Name = "EditorialAssistant", Description = "Assists with editing and content management.", isUnique = false },
            new RoleType { Id = 5, Name = "ContributingWriter", Description = "Writes articles or content on a regular basis.", isUnique = false },
            new RoleType { Id = 6, Name = "GuestWriter", Description = "Contributes content occasionally, usually for special topics.", isUnique = false },
            new RoleType { Id = 7, Name = "VoiceOver", Description = "Provides narration or voiceovers for the podcast version.", isUnique = false }
        };
    }
}

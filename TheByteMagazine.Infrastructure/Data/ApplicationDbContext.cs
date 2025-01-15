using TheByteMagazine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TheByteMagazine.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }


    public DbSet<Issue> Issues { get; set; }
    public DbSet<Article> Articles { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<RoleType> RoleTypes { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<Message> Messages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        //modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
        ////modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
        //modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
        //modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
        //modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
        //modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
        //modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
    }
}

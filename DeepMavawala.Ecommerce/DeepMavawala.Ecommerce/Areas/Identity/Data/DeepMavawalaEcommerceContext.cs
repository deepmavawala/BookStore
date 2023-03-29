using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeepMavawala.Ecommerce.Data;

public class DeepMavawalaEcommerceContext : IdentityDbContext<IdentityUser>
{
    public DeepMavawalaEcommerceContext(DbContextOptions<DeepMavawalaEcommerceContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.HasDefaultSchema("Identity");
        builder.Entity<IdentityUser>(entity => { 
            entity.ToTable(name:"User");
        });
        builder.Entity<IdentityRole>(entity => {
            entity.ToTable(name: "Role");
        });
        builder.Entity<IdentityUserRole<string>>(entity => {
            entity.ToTable(name: "UserRoles");
        });
        builder.Entity<IdentityUserClaim<string>>(entity => {
            entity.ToTable(name: "UserClaims");
        });
        builder.Entity<IdentityUserLogin<string>>(entity => {
            entity.ToTable(name: "UserLogins");
        });
        builder.Entity<IdentityRoleClaim<string>>(entity => {
            entity.ToTable(name: "RoleClaims");
        });
        builder.Entity<IdentityUserToken<string>>(entity => {
            entity.ToTable(name: "UserTokens");
        });
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManager.Identity.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole> {
    public void Configure(EntityTypeBuilder<IdentityRole> builder) {
        builder.HasData (
            new IdentityRole {
                Id = "b84ecb4e-5150-4f02-b59f-4aae28acf118",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole { 
                Id = "628f0181-2e40-4848-a0f0-fe2c42e9209e",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}

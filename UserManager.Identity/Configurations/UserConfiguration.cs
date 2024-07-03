using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Identity.Models;

namespace UserManager.Identity.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser> {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder) {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
            new ApplicationUser {
                Id = "b6bb4218-a1bb-45fc-9fa9-31519e523754",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin@duett.com",
                Email = "admin@duett.com",
                NormalizedEmail = "ADMIN@DUETT.COM",
                Cpf = "00000000000",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApplicationUser {
                Id = "ebba5465-9c71-443e-b035-6438699dabaa",
                FirstName = "System",
                LastName = "User",
                UserName = "user@duett.com",
                Email = "user@duett.com",
                Cpf = "11111111111",
                NormalizedEmail = "USER@DUETT.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
        );
    }
}

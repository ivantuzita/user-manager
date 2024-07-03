using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UserManager.Identity.Configurations {
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>> {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder) {
            builder.HasData(
                new IdentityUserRole<string> {
                    RoleId = "b84ecb4e-5150-4f02-b59f-4aae28acf118",
                    UserId = "ebba5465-9c71-443e-b035-6438699dabaa"
                },
                new IdentityUserRole<string> {
                    RoleId = "628f0181-2e40-4848-a0f0-fe2c42e9209e",
                    UserId = "b6bb4218-a1bb-45fc-9fa9-31519e523754"
                }
            );
        }
    }
}

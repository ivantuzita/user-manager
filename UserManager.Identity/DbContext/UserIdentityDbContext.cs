
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManager.Identity.Models;

namespace UserManager.Identity.DbContext; 
public class UserIdentityDbContext : IdentityDbContext<ApplicationUser> {
    public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(UserIdentityDbContext).Assembly);
    }
}

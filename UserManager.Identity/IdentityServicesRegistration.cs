using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Models.Identity;
using UserManager.Identity.DbContext;
using UserManager.Identity.Models;
using UserManager.Identity.Services;

namespace UserManager.Identity {
    public static class IdentityServicesRegistration {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration) {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<UserIdentityDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("UserManagerConnectionString"));
        });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UserIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                        (configuration["JwtSettings:Key"]!)!)
                };
            });

            return services;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManager.Application.Exceptions;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Models.Identity;
using UserManager.Identity.Models;

namespace UserManager.Identity.Services;
public class AuthService : IAuthService {

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;
    public AuthService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<AuthResponse> Login(AuthRequest request) {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null) {
            throw new NotFoundException($"E-mail [{request.Email} was not found.]");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded) {
            throw new BadRequestException($"Incorrect password. Please double-check your spelling and try again.");
        }

        JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

        var response = new AuthResponse {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Email = user.Email,
            Username = user.UserName
        };

        return response;
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user) { 
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials);
        return jwtSecurityToken;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)  {
        

        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null) {
            return new RegistrationResponse { Errors = "Email is already taken." };
        }

        var existingCpf = await _userManager.Users.FirstOrDefaultAsync(u => u.Cpf == request.CPF);
        if (existingCpf != null) {
            return new RegistrationResponse { Errors = "Cpf is already registered." };
        }

        var user = new ApplicationUser {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Cpf = request.CPF,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (result.Succeeded) {
            await _userManager.AddToRoleAsync(user, "User");

            return new RegistrationResponse { UserId = user.Id };
        }
        else {
            StringBuilder errors = new StringBuilder();
            foreach (var error in result.Errors) {
                errors.AppendLine(error.Description);
            }
            return new RegistrationResponse { Errors = errors.ToString() };
        }
    }

    public async Task<PasswordChangeResponse> ChangePassword(PasswordChangeRequest passwordChangeRequest) {
        var user = await _userManager.FindByNameAsync(passwordChangeRequest.Username);
        if (user == null) {
            return new PasswordChangeResponse { Errors = "User not found." };
        }

        var passwordValid = await _userManager.CheckPasswordAsync(user, passwordChangeRequest.CurrentPassword);
        if (!passwordValid) {
            return new PasswordChangeResponse { Errors = "Current password is incorrect." };
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, passwordChangeRequest.NewPassword);

        if (result.Succeeded) {
            return new PasswordChangeResponse { Success = true };
        }
        else {
            StringBuilder errors = new StringBuilder();
            foreach (var error in result.Errors) {
                errors.AppendLine(error.Description);
            }
            return new PasswordChangeResponse { Errors = errors.ToString() };
        }
    }
}
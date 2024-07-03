using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Models;
using UserManager.Domain.Models.Identity;
using UserManager.Identity.Models;

namespace UserManager.Identity.Services;
public class UserService : IUserService {

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager) {
        _userManager = userManager;
    }

    public async Task<User> GetUserById(string userId) {
        var user = await _userManager.FindByIdAsync(userId);
        return new User {
            Email = user.Email,
            Id = user.Id,
            Firstname = user.FirstName,
            Lastname = user.LastName,
            Cpf = user.Cpf
        };
    }

    public async Task<List<User>> GetAllUsersAsync() {
        var users = await _userManager.GetUsersInRoleAsync("User");
        return users.Select(q => new User {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName,
            Cpf = q.Cpf
        }).ToList();
    }

    public async Task DeleteAsync(string id) {
        var user = await _userManager.FindByIdAsync(id);
        var result = await _userManager.DeleteAsync(user);
    }
}

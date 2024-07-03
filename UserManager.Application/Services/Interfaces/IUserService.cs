using UserManager.Domain.Models.Identity;

namespace UserManager.Application.Services.Interfaces {
    public interface IUserService {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserById(string id);
        Task DeleteAsync(string id);
    }
}

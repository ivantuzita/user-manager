using UserManager.Domain.Models;

namespace UserManager.Domain.Interfaces;
public interface IUserRepository {
    Task<User> GetByIdAsync(int id);
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(int id);
}

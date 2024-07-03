using UserManager.BlazorUI.Models.Authentication;

namespace UserManager.BlazorUI.Interfaces; 
public interface IUserService {
    Task<AppUserVM> GetUserById(string id);
    Task<List<AppUserVM>> GetAllUsers();
    Task Delete(string id);
}

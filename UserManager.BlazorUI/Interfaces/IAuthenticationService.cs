using UserManager.BlazorUI.Services.Base;

namespace UserManager.BlazorUI.Interfaces; 
public interface IAuthenticationService {
    Task<bool> AuthenticateAsync(string email, string password);
    Task<RegistrationResponse> RegisterAsync(string firstName, string lastName, string userName, string email, string password, string cpf);
    Task Logout();
    Task<PasswordChangeResponse> PasswordChangeAsync(string username, string currentPassword, string newPassword);
}

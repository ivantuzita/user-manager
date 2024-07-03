using UserManager.Domain.Models.Identity;

namespace UserManager.Application.Services.Interfaces {
    public interface IAuthService {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<PasswordChangeResponse> ChangePassword(PasswordChangeRequest passwordChangeRequest);
    }
}

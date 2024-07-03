using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Models.Identity;

namespace UserManager.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller {

    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request) {
        return Ok(await _authService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request) {
        return Ok(await _authService.Register(request));
    }

    [HttpPost("changepassword")]
    public async Task<ActionResult<PasswordChangeResponse>> ChangePassword(PasswordChangeRequest request) {
        return Ok(await _authService.ChangePassword(request));
    }
}

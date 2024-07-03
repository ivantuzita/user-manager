using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Services.Interfaces;
using UserManager.Domain.Models.Identity;

namespace UserManager.Identity.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers() {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id) {
                var user = await _userService.GetUserById(id);
                return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id) {
            await _userService.DeleteAsync(id);
            return Ok($"User with ID {id} deleted successfully.");
        }
    }
}

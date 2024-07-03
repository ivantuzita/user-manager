using AutoMapper;
using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Models.Authentication;
using UserManager.BlazorUI.Services.Base;

namespace UserManager.BlazorUI.Services {
    public class UserService : BaseHttpService, IUserService {
        private readonly IMapper _mapper;
        public UserService(IClient client, IMapper mapper) : base(client)
        {
            _mapper = mapper;
        }
        public async Task<List<AppUserVM>> GetAllUsers() {
            var result = await _client.UsersAllAsync();
            return _mapper.Map<List<AppUserVM>>(result);
        }

        public async Task Delete(string id) {
            await _client.UsersDELETEAsync(id);
        }

        public async Task<AppUserVM> GetUserById(string id) {
            var result = await _client.UsersGETAsync(id);
            return _mapper.Map<AppUserVM>(result);
        }
    }
}

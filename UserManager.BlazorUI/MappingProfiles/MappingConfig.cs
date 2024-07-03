using AutoMapper;
using UserManager.BlazorUI.Models.Authentication;
using UserManager.BlazorUI.Services.Base;

namespace UserManager.BlazorUI.MappingProfiles {
    public class MappingConfig : Profile {
        public MappingConfig()
        {
            CreateMap<User, AppUserVM>().ReverseMap();
        }
    }
}

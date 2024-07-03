using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using UserManager.BlazorUI.Interfaces;
using UserManager.BlazorUI.Providers;
using UserManager.BlazorUI.Models.Authentication;
using Blazored.Toast.Services;

namespace UserManager.BlazorUI.Pages {
    public partial class Index {
        public List<AppUserVM> Model { get; set; } = new List<AppUserVM>();
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        IToastService toastService { get; set; }

        protected async override Task OnInitializedAsync() {
            await ((ApiAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
            Model = await UserService.GetAllUsers();
        }

        protected async Task DeleteUser(string id) {
            await UserService.Delete(id);
            toastService.ShowSuccess($"Succesfully deleted user!");
            NavigationManager.Refresh();
        }
    }
}
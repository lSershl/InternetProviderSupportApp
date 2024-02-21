using IPSA.Shared.Contracts;
using IPSA.Shared.Dtos;
using IPSA.Shared.Responses;
using IPSA.Web.States;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace IPSA.Web.Components.Pages
{
    public class LoginPageBase : ComponentBase
    {
        [Inject]
        public required IAccountService accountService { get; set; }
        [Inject]
        public required IJSRuntime js {  get; set; }
        [Inject]
        public required AuthenticationStateProvider authStateProvider { get; set; }
        [Inject]
        public required NavigationManager navManager { get; set; }


        protected LoginDto Login = new();

        public async Task LoginClicked()
        {
            LoginResponse response = await accountService.LoginAsync(Login);
            //if (response is not null)
            //{
            //    await js.InvokeVoidAsync("alert", response.Message);
            //    return;
            //}

            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            customAuthStateProvider.UpdateAuthenticationState(response.JWTToken);
            navManager.NavigateTo("/", forceLoad: true);
        }
    }
}

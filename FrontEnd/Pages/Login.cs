using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages;

public partial class Login
{
    private Userlogin user = new Userlogin();
    private string errorMessage = string.Empty;

    [Inject] 
    private IAuthService AuthService { get; set; }

    [Inject] 
    private ILocalStorageService LocalStorageService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    private async Task HandleLogin()
    {
        var result = await AuthService.Login(user);
        if (result.Success)
        {
            errorMessage = string.Empty;

            await LocalStorageService.SetItemAsync("authToken", result.Data);
            /*await AuthenticationStateProvider.GetAuthenticationStateAsync();
            await CartService.StoreCartItems(true);
            await CartService.GetCartItemsCount();*/
            NavigationManager.NavigateTo("");
        }
        else
        {
            errorMessage = result.Message;
        }
    }
}
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace FrontEnd.Pages;

public partial class Login
{
    private Userlogin user = new Userlogin();
    private string errorMessage = string.Empty;
    private string returnUrl = string.Empty;

    [Inject] 
    private IAuthService AuthService { get; set; }

    [Inject] 
    private ILocalStorageService LocalStorageService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    
    protected override void OnInitialized()
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
        if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("returnUrl", out var url))
        {
            returnUrl = url;
        }
    }
    
    
    private async Task HandleLogin()
    {
        var result = await AuthService.Login(user);
        if (result.Success)
        {
            errorMessage = string.Empty;

            await LocalStorageService.SetItemAsync("authToken", result.Data);
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            /*await CartService.StoreCartItems(true);
            await CartService.GetCartItemsCount();*/
            NavigationManager.NavigateTo(returnUrl);
        }
        else
        {
            errorMessage = result.Message;
        }
    }
}
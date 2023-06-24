using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages;

public partial class Profile
{
    Userchangepassword request = new Userchangepassword();
    string message = string.Empty;
    
    [Inject] 
    private IAuthService AuthService { get; set; }

    private async Task ChangePassword()
    {
        var result = await AuthService.ChangePassword(request);
        message = result.Message;
    }
}
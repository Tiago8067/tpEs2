namespace FrontEnd.Pages;

public partial class Registo
{
    Userregisto user = new Userregisto();
    
    string message = string.Empty;
    string messageCssClass = string.Empty;
    
    async Task HandleRegistration()
    {
        var result = await AuthService.Registo(user);
        message = result.Message;
        if (result.Success)
            messageCssClass = "text-success";
        else
            messageCssClass = "text-danger";
    }
}
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesUserManager;

public partial class UtilUmDetalhes
{
    protected string Message = string.Empty;
    protected string MessageCssClass = string.Empty;
    protected Usermodel Utilizador { get; set; } = new Usermodel();
    protected Userregisto user = new Userregisto();
    
    private List<string> _tipoUser = new List<string>
    {
        "User",
        "UserManager"
    };
    
    [Parameter]
    public string Id { get; set; }
    
    [Inject]
    private IUtilizadorService UtilizadorService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    protected async override Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            
        }
        else
        {
            Guid utilizadorId = Guid.Parse(Id);

            var apiUtilizador = await UtilizadorService.GetUtilizador(utilizadorId);

            if (apiUtilizador != null)
            {
                Utilizador = apiUtilizador;
            }
        }
    }
    
    protected void HandleFailedResquest()
    {
        Message = "Algo correu mal, formulário não foi submetido";
    }
    
    protected void GoToUtilizadors()
    {
        NavigationManager.NavigateTo("/utilum");
    }
    
    protected async Task DeleteUtilizador()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            Guid utilId = Guid.Parse(Id);

            var result = await UtilizadorService.DeleteUtilizador(utilId);

            if (result)
            {
                NavigationManager.NavigateTo("/utilum");
            }
            else
            {
                Message = "Algo correu mal, o utilizador não foi apagado";
            }
        }
    }
    
    protected async void HandleValidResquest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            var result = await UtilizadorService.AddUtilizador(user);

            Message = result.Message;
            if (result.Success)
            {
                MessageCssClass = "text-success";
                NavigationManager.NavigateTo("/utilum");   
            }
            else
            {
                MessageCssClass = "text-danger";
            }
        }
        else
        {
            var result = await UtilizadorService.UpdateUtilizador(Utilizador.Id, Utilizador);

            if (result)
            {
                NavigationManager.NavigateTo("/utilum");
            }
            else
            {
                Message = "Algo correu mal, o utilizador nao foi atualizado (pode estar a Repetir algum Email)";
            }
        }
    }
}
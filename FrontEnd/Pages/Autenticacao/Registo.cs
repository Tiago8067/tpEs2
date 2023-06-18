using BusinessLogic.Entities;
using FrontEnd.Services.UtilizadorService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.Autenticacao;

public partial class Registo
{
    protected string Message = string.Empty;
    protected Utilizador Utilizador { get; set; } = new Utilizador();
    
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
        NavigationManager.NavigateTo("/utilizadores");
    }
    
    protected async Task DeleteUtilizador()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            Guid utilId = Guid.Parse(Id);

            var result = await UtilizadorService.DeleteUtilizador(utilId);

            if (result)
            {
                NavigationManager.NavigateTo("/utilizadores");
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
            var result = await UtilizadorService.AddUtilizador(Utilizador);

            if (result)
            {
                NavigationManager.NavigateTo("/utilizadores");
            }
            else
            {
                Message = "Algo correu mal, o utilizador nao foi adicionado";
            }
        }
        else
        {
            var result = await UtilizadorService.UpdateUtilizador(Utilizador.Id, Utilizador);

            if (result)
            {
                NavigationManager.NavigateTo("/utilizadores");
            }
            else
            {
                Message = "Algo correu mal, o utilizador nao foi atulizado";
            }
        }
    }
}
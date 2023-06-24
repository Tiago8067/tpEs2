using System.Net;
using FrontEnd.Services.ProjetoService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesProjeto;

public partial class ProjetoDetalhes
{
    protected string Message = string.Empty;
    protected Projeto Projeto { get; set; } = new Projeto();
    
    [Parameter]
    public string Id { get; set; }
    
    [Inject]
    private IProjetoService ProjetoService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        if (string.IsNullOrEmpty(Id))
        {
            
        }
        else
        {
            Guid projetoId = Guid.Parse(Id);

            var apiProjeto = await ProjetoService.GetProjeto(projetoId);

            if (apiProjeto != null)
            {
                Projeto = apiProjeto;
            }
        }
    }
    
    protected void HandleFailedResquest()
    {
        Message = "Algo correu mal, formulário não foi submetido";
    }
    
    protected void GoToProjects()
    {
        NavigationManager.NavigateTo("/projetos");
    }
    
    protected async Task DeleteProjeto()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            Guid utilId = Guid.Parse(Id);

            var result = await ProjetoService.DeleteProjeto(utilId);

            if (result)
            {
                NavigationManager.NavigateTo("/projetos");
            }
            else
            {
                Message = "Algo correu mal, o projeto não foi apagado";
            }
        }
    }
    
    protected async void HandleValidResquest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            var result = await ProjetoService.AddProjeto(Projeto);

            if (result)
            {
                NavigationManager.NavigateTo("/projetos");
            }
            else
            {
                Message = "Algo correu mal, o projeto nao foi adicionado";
            }
        }
        else
        {
            var result = await ProjetoService.UpdateProjeto(Projeto.Id, Projeto);

            if (result)
            {
                NavigationManager.NavigateTo("/projetos");
            }
            else
            {
                Message = "Algo correu mal, o projeto nao foi atulizado";
            }
        }
        
        if (HttpStatusCode.BadRequest != (HttpStatusCode)0 || HttpStatusCode.InternalServerError != (HttpStatusCode)0) //Encontrar o 200
        {
            Message = "O Nome Projeto já existe! Insira outro.";
        }
    }
}
using BusinessLogic.Entities;
using FrontEnd.Services.ProjetoService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesProjeto;

public partial class Projetos
{
    [Inject]
    private IProjetoService ProjetoService { get; set; }

    public IEnumerable<Projeto> Projects { get; set; } = new List<Projeto>();

    protected async override Task OnInitializedAsync()
    {
        var apiProjects = await ProjetoService.AllProjetos();

        if (apiProjects != null && apiProjects.Any())
        {
            Projects = apiProjects;
        }
    }
}
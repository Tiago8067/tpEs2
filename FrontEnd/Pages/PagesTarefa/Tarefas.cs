using BusinessLogic.Entities;
using FrontEnd.Services.TarefaService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesTarefa;

public partial class Tarefas
{
    [Inject]
    private ITarefaService TarefaService { get; set; }

    public IEnumerable<Tarefa> Tasks { get; set; } = new List<Tarefa>();

    protected override async Task OnInitializedAsync()
    {
        var apiTasks = await TarefaService.AllTarefas();

        if (apiTasks != null && apiTasks.Any())
        {
            Tasks = apiTasks;
        }
    }
}
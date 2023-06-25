using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesTarefa;

public partial class TarefasEmCurso
{
    [Inject]
    private ITarefaService TarefaService { get; set; }

    private DateTime tempoTarefa = DateTime.UtcNow;

    private TimeSpan diferenca = new TimeSpan();

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
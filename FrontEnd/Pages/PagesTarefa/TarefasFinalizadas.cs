using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesTarefa;

public partial class TarefasFinalizadas
{
    [Inject]
    private ITarefaService TarefaService { get; set; }

    public IEnumerable<Tarefa> Tasks { get; set; } = new List<Tarefa>();
    
    private List<Tarefa> _filtrarTarefas = new List<Tarefa>();
    private DateTime startDate;
    private DateTime endDate;
    
    protected override async Task OnInitializedAsync()
    {
        /*var apiTasks = await TarefaService.AllTarefas();

        if (apiTasks != null && apiTasks.Any())
        {
            Tasks = apiTasks;
        }*/
        
        Tasks = await TarefaService.AllTarefas();
        _filtrarTarefas = (List<Tarefa>)Tasks;
    }
    
    private void FiltrarTarefas()
    {
        _filtrarTarefas = Tasks.Where(t => t.DataHoraFim >= startDate && t.DataHoraFim <= endDate).ToList();
    }
}
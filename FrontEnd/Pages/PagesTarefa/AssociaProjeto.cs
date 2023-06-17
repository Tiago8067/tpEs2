using BusinessLogic.Entities;
using FrontEnd.Services.ProjetoService;
using FrontEnd.Services.TarefaService;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;

namespace FrontEnd.Pages.PagesTarefa;

public partial class AssociaProjeto
{
    protected string Message = string.Empty;
    protected Tarefa Task { get; set; } = new Tarefa();

    [Inject]
    private ITarefaService TarefaService { get; set; }
    
    [Inject]
    private IProjetoService ProjetoService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    
    [Parameter]
    public string Id { get; set; }

    public IEnumerable<Tarefa>? Tarefas { get; set; } = new List<Tarefa>();
    
    public IEnumerable<Projeto>? Projects { get; set; } = new List<Projeto>();

    protected override async Task OnInitializedAsync()
    {
        Tarefas = await TarefaService.AllTarefas();
        Projects = await ProjetoService.AllProjetos();
        
        if (string.IsNullOrEmpty(Id))
        {
            
        }
        else
        {
            Guid taskId = Guid.Parse(Id);

            var apiTask = await TarefaService.GetTarefa(taskId);

            if (apiTask != null)
            {
                Task = apiTask;
            }
        }
    }

    public void OnValueChangeProject(ChangeEventArgs<string, Projeto> args)
    {
        if (Task.Projeto != null)
        {
            Task.Projeto.Nome = args.ItemData.Nome;
        }
    }
    
    protected async void HandleValidResquest()
    {
        if (false) return;
        /*Message = "";*/
        // todo fazer metodo para inserir o projeto na tarefa, ou seja, associar verificar se sera put ou post
        var result = await TarefaService.UpdateTarefa(Task.Id, Task);
        /*Message = result.Message!;*/
        if (result)
        {
            NavigationManager.NavigateTo("/tarefas");
        }
        else
        {
            Message = "Algo correu mal, a tarefa nao foi associada a projeto";
        }
    }
}
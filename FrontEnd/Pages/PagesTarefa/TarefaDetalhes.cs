using BusinessLogic.Entities;
using FrontEnd.Services.TarefaService;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesTarefa;

public partial class TarefaDetalhes
{
    protected string Message = string.Empty;
    protected Tarefa Task { get; set; } = new Tarefa();
    
    [Parameter]
    public string Id { get; set; }
    
    [Inject]
    private ITarefaService TarefaService { get; set; }
    
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
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
    
    protected void HandleFailedResquest()
    {
        Message = "Algo correu mal, formulário não foi submetido";
    }
    
    protected void GoToTasks()
    {
        NavigationManager.NavigateTo("/tarefas");
    }
    
    protected async Task DeleteTask()
    {
        if (!string.IsNullOrEmpty(Id))
        {
            Guid taskId = Guid.Parse(Id);

            var result = await TarefaService.DeleteTarefa(taskId);

            if (result)
            {
                NavigationManager.NavigateTo("/tarefas");
            }
            else
            {
                Message = "Algo correu mal, a tarefa não foi apagada";
            }
        }
    }
    
    protected async void HandleValidResquest()
    {
        if (string.IsNullOrEmpty(Id))
        {
            var result = await TarefaService.AddTarefa(Task);

            if (result)
            {
                NavigationManager.NavigateTo("/tarefas");
            }
            else
            {
                Message = "Algo correu mal, a tarefa nao foi adicionada";
            }
        }
        else
        {
            var result = await TarefaService.UpdateTarefa(Task.Id, Task);

            if (result)
            {
                NavigationManager.NavigateTo("/tarefas");
            }
            else
            {
                Message = "Algo correu mal, a tarefa nao foi atulizada";
            }
        }
    }
}
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Components;

namespace FrontEnd.Pages.PagesTarefa;

public partial class AssociaProjeto
{
    protected Tarefa Task { get; set; } = new Tarefa();
    
    [Parameter]
    public string Id { get; set; }
}
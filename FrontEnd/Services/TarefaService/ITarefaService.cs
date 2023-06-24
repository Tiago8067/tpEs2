namespace FrontEnd.Services.TarefaService;

public interface ITarefaService
{
    Task<IEnumerable<Tarefa>?> AllTarefas();
    Task<Tarefa?> GetTarefa(Guid id);
    Task<bool> AddTarefa(Tarefa tarefa);
    Task<bool> UpdateTarefa(Guid id, Tarefa tarefa);
    Task<bool> DeleteTarefa(Guid id);
    //Task<bool> AssociaTarefaProjeto(Guid tarefaId, Projeto projeto);
}
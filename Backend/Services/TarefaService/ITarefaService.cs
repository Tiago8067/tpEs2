namespace Backend.Services.TarefaService;

public interface ITarefaService
{
    Task<List<Tarefa>> GetAllTarefas();
    Task<Tarefa?> GetTarefaById(Guid id);
    Task<List<Tarefa>> AddTarefa(Tarefa tarefa);
    Task<List<Tarefa>?> UpdateTarefa(Guid id, Tarefa request);
    Task<List<Tarefa>?> DeleteTarefa(Guid id);

    Task<List<Tarefa>> AssociateTarefaProjeto(Guid tarefaId, String NomeProj);
}
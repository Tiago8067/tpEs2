namespace Backend.Services.UtililizadorService;

public interface IUtilizadorService
{
    Task<List<Utilizadore>> GetAllUtilizadores();
    Task<Utilizadore?> GetUtilizadorById(Guid id);
    Task<List<Utilizadore>> AddUtilizador(Utilizadore utilizador);
    Task<List<Utilizadore>?> UpdateUtilizador(Guid id, Utilizadore request);
    Task<List<Utilizadore>?> DeleteUtilizador(Guid id);
}
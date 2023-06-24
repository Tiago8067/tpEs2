namespace FrontEnd.Services.UtilizadorService;

public interface IUtilizadorService
{
    Task<IEnumerable<Utilizadore>?> All();
    Task<Utilizadore?> GetUtilizador(Guid id);
    Task<bool> AddUtilizador(Utilizadore utilizador);
    Task<bool> UpdateUtilizador(Guid id, Utilizadore utilizador);
    Task<bool> DeleteUtilizador(Guid id);
}
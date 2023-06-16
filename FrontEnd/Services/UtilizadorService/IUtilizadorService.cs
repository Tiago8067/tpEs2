using BusinessLogic.Entities;

namespace FrontEnd.Services.UtilizadorService;

public interface IUtilizadorService
{
    Task<IEnumerable<Utilizador>?> All();
    Task<Utilizador?> GetUtilizador(Guid id);
    Task<bool> AddUtilizador(Utilizador utilizador);
    Task<bool> UpdateUtilizador(Guid id, Utilizador utilizador);
    Task<bool> DeleteUtilizador(Guid id);
}
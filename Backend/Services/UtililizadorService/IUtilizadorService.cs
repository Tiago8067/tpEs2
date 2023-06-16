using BusinessLogic.Entities;

namespace Backend.Services.UtililizadorService;

public interface IUtilizadorService
{
    Task<List<Utilizador>> GetAllUtilizadores();
    Task<Utilizador?> GetUtilizadorById(Guid id);
    Task<List<Utilizador>> AddUtilizador(Utilizador utilizador);
    Task<List<Utilizador>?> UpdateUtilizador(Guid id, Utilizador request);
    Task<List<Utilizador>?> DeleteUtilizador(Guid id);
}
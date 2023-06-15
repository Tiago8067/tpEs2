using BusinessLogic.Entities;

namespace FrontEnd.Services.UtilizadorService;

public interface IUtilizadorService
{
    List<Utilizador> Utilizadores { get; set; }
    /*<List<Utilizador>>*/
    Task GetUtilizadores();
    Task<Utilizador?> GetUtilizadorById(Guid id);
    Task CreateUtilizador(Utilizador utilizador);
    Task UpdateUtilizador(Guid id, Utilizador utilizador);
    Task DeleteUtilizador(Guid id);
}
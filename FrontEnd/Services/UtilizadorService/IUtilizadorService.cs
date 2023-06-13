using BusinessLogic.Entities;

namespace FrontEnd.Services.UtilizadorService;

public interface IUtilizadorService
{
    List<Utilizador> Utilizadores { get; set; }
    Task GetUtilizadores();
    Task<Utilizador?> GetUtilizadorById(int id);
    Task CreateUtilizador(Utilizador utilizador);
    Task UpdateUtilizador(int id, Utilizador utilizador);
    Task DeleteUtilizador(int id);
}
using BusinessLogic.Entities;

namespace BlazorApp1.Services;

public interface IUtilizador
{
    List<Utilizador> Utilizadores { get; set; } /*<List<Utilizador>>*/
    Task GetUtilizadores();
}
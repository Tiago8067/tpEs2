namespace Backend.Services.UtilizadorService;

public interface IUtilizadorService
{
    List<Utilizador> GetAllUtilizadores();
    Utilizador? GetUtilizadorById(Guid id);
    List<Utilizador> AddUtilizador(Utilizador utilizador);
    List<Utilizador>? UpdateUtilizador(Guid id, Utilizador request);
    List<Utilizador>? DeleteUtilizador(Guid id);
}
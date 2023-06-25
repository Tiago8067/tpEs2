namespace FrontEnd.Services.UtilizadorService;

public interface IUtilizadorService
{
    Task<IEnumerable<Usermodel>?> All();
    Task<Usermodel?> GetUtilizador(Guid id);
    //Task<bool> AddUtilizador(Usermodel utilizador);
    Task<ServiceResponse<Guid>> AddUtilizador(Userregisto request);
    Task<bool> UpdateUtilizador(Guid id, Usermodel utilizador);
    Task<bool> DeleteUtilizador(Guid id);
}
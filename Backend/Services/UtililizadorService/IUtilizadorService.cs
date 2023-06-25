namespace Backend.Services.UtililizadorService;

public interface IUtilizadorService
{
    Task<List<Usermodel>> GetAllUtilizadores();
    Task<Usermodel?> GetUtilizadorById(Guid id);
    //Task<List<Usermodel>> AddUtilizador(Usermodel utilizador);
    Task<ServiceResponse<Guid>> AddUtilizador(Usermodel user, string password);
    Task<List<Usermodel>?> UpdateUtilizador(Guid id, Usermodel request);
    Task<List<Usermodel>?> DeleteUtilizador(Guid id);
}
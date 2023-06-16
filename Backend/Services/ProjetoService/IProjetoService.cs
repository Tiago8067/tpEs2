using BusinessLogic.Entities;

namespace Backend.Services.ProjetoService;

public interface IProjetoService
{
    Task<List<Projeto>> GetAllProjetos();
    Task<Projeto?> GetProjetoById(Guid id);
    Task<List<Projeto>> AddProjeto(Projeto projeto);
    Task<List<Projeto>?> UpdateProjeto(Guid id, Projeto request);
    Task<List<Projeto>?> DeleteProjeto(Guid id);
}
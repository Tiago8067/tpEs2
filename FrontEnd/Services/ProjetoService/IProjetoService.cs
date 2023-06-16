using BusinessLogic.Entities;

namespace FrontEnd.Services.ProjetoService;

public interface IProjetoService
{
    Task<IEnumerable<Projeto>?> AllProjetos();
    Task<Projeto?> GetProjeto(Guid id);
    Task<bool> AddProjeto(Projeto projeto);
    Task<bool> UpdateProjeto(Guid id, Projeto projeto);
    Task<bool> DeleteProjeto(Guid id);
}
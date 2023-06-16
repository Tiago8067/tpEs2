using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.ProjetoService;

public class ProjetoService : IProjetoService
{
    private readonly TarefasDbContexta _contexta;

    public ProjetoService(TarefasDbContexta contexta)
    {
        _contexta = contexta;
    }

    public async Task<List<Projeto>> GetAllProjetos()
    {
        return await _contexta.Projetos.ToListAsync();
    }

    public async Task<Projeto?> GetProjetoById(Guid id)
    {
        var projeto = await _contexta.Projetos.FindAsync(id);
        if (projeto is null)
        {
            return null;
        }
        return projeto;
    }

    public async Task<List<Projeto>> AddProjeto(Projeto projeto)
    {
        _contexta.Projetos.Add(projeto);
        await _contexta.SaveChangesAsync();
        return await _contexta.Projetos.ToListAsync();
    }

    public async Task<List<Projeto>?> UpdateProjeto(Guid id, Projeto request)
    {
        var projeto = await _contexta.Projetos.FindAsync(id);
        if (projeto is null)
        {
            return null;
        }

        projeto.Nome = request.Nome;
        projeto.NomeCliente = request.NomeCliente;
        projeto.PrecoPorHora = request.PrecoPorHora;
        
        await _contexta.SaveChangesAsync();
        
        return await _contexta.Projetos.ToListAsync();
    }

    public async Task<List<Projeto>?> DeleteProjeto(Guid id)
    {
        var projeto = await _contexta.Projetos.FindAsync(id);
        if (projeto is null)
        {
            return null;
        }
        _contexta.Projetos.Remove(projeto);
        await _contexta.SaveChangesAsync();
        return await _contexta.Projetos.ToListAsync();
    }
}
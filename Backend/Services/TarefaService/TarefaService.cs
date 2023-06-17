using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.TarefaService;

public class TarefaService : ITarefaService
{
    private readonly TarefasDbContexta _contexta;

    public TarefaService(TarefasDbContexta contexta)
    {
        _contexta = contexta;
    }

    public async Task<List<Tarefa>> GetAllTarefas()
    {
        return await _contexta.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> GetTarefaById(Guid id)
    {
        var tarefa = await _contexta.Tarefas.FindAsync(id);
        if (tarefa is null)
        {
            return null;
        }
        return tarefa;
    }

    public async Task<List<Tarefa>> AddTarefa(Tarefa tarefa)
    {
        _contexta.Tarefas.Add(tarefa);
        await _contexta.SaveChangesAsync();
        return await _contexta.Tarefas.ToListAsync();
    }

    public async Task<List<Tarefa>?> UpdateTarefa(Guid id, Tarefa request)
    {
        var tarefa = await _contexta.Tarefas.FindAsync(id);
        if (tarefa is null)
        {
            return null;
        }

        tarefa.CurtaDescricao = request.CurtaDescricao;
        tarefa.DataHoraInicio = request.DataHoraInicio;
        tarefa.DataHoraFim = request.DataHoraFim;
        tarefa.EstadoTarefa = request.EstadoTarefa;
        
        await _contexta.SaveChangesAsync();
        
        return await _contexta.Tarefas.ToListAsync();
    }

    public async Task<List<Tarefa>?> DeleteTarefa(Guid id)
    {
        var tarefa = await _contexta.Tarefas.FindAsync(id);
        if (tarefa is null)
        {
            return null;
        }
        _contexta.Tarefas.Remove(tarefa);
        await _contexta.SaveChangesAsync();
        return await _contexta.Tarefas.ToListAsync();
    }

    public async Task<List<Tarefa>> AssociateTarefaProjeto(Guid tarefaId, Guid projetoId, Tarefa request)
    {
        var tarefa = await _contexta.Tarefas.FindAsync(tarefaId);
        if (tarefa is null)
        {
            return null;
        }
        var projeto = await _contexta.Projetos.FindAsync(projetoId);
        if (projeto is null)
        {
            return null;
        }

        tarefa.ProjetoId = projetoId;
        //tarefa.ProjetoId = request.ProjetoId;
        
        //tarefa.Projeto.Nome = projeto.Nome;
        //tarefa.Projeto.NomeCliente = projeto.NomeCliente;
        //tarefa.Projeto.PrecoPorHora = projeto.PrecoPorHora;

        await _contexta.SaveChangesAsync();
        
        return await _contexta.Tarefas.ToListAsync();
    }
}
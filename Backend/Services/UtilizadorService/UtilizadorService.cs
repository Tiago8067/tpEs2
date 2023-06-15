using BusinessLogic.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly TarefasDbContext _context;

    public UtilizadorService(TarefasDbContext context)
    {
        _context = context;
    }
    
    //public async Task<ActionResult<IEnumerable<dynamic>>> GetAllUtilizadores()
    public async Task<List<Utilizador>> GetAllUtilizadores()
    {
        /*var utilizadores = await _context.Utilizadores.ToListAsync();
        return utilizadores;*/
        return await _context.Utilizadores.ToListAsync();

        /*return await _context
            .Utilizadores.Select(u => new
            {
                u.Id,
                u.Email,
                u.Username,
                u.Password,
                u.Nome,
                u.Genero,
                u.DataDeNascimento,
                u.CodigoPostal,
                u.Morada,
                u.TipoUtilizador,
                u.EstadoUtilizador,
                Projetos = u.Projetos.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.NomeCliente,
                    p.PrecoPorHora,
                    Tarefas = p.Tarefas.Select(t => new
                    {
                        t.Id,
                        t.CurtaDescricao,
                        t.DataHoraInicio,
                        t.DataHoraFim,
                        t.EstadoTarefa
                    })
                })
            }).ToListAsync();*/
    }

    public async Task<Utilizador?> GetUtilizadorById(Guid id)
    {
        var utilizador = await _context.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        return utilizador;
    }

    public async Task<List<Utilizador>> AddUtilizador(Utilizador utilizador)
    {
        _context.Utilizadores.Add(utilizador);
        await _context.SaveChangesAsync();
        return await _context.Utilizadores.ToListAsync();
    }

    public async Task<List<Utilizador>?> UpdateUtilizador(Guid id, Utilizador request)
    {
        var utilizador = await _context.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }

        // utilizador.Id = request.Id;
        utilizador.Email = request.Email;
        utilizador.Username = request.Username;
        utilizador.Password = request.Password;
        utilizador.Nome = request.Nome;
        utilizador.Genero = request.Genero;
        utilizador.DataDeNascimento = request.DataDeNascimento;
        utilizador.CodigoPostal = request.CodigoPostal;
        utilizador.Morada = request.Morada;
        utilizador.TipoUtilizador = request.TipoUtilizador;
        utilizador.EstadoUtilizador = request.EstadoUtilizador;

        await _context.SaveChangesAsync();
        
        return await _context.Utilizadores.ToListAsync();
    }

    public async Task<List<Utilizador>?> DeleteUtilizador(Guid id)
    {
        var utilizador = await _context.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        _context.Utilizadores.Remove(utilizador);
        await _context.SaveChangesAsync();
        return await _context.Utilizadores.ToListAsync();
    }
}
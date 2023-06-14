using BusinessLogic.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly TarefasProjetosDbContext _context;

    public UtilizadorService(TarefasProjetosDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Utilizador>> GetAllUtilizadores()
    {
        return await _context.Utilizadores.ToListAsync();
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
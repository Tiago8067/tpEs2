using BusinessLogic.Context;
using BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UtililizadorService;

public class UtilizadorService : IUtilizadorService
{
    private readonly TarefasDbContexta _contexta;

    public UtilizadorService(TarefasDbContexta contexta)
    {
        _contexta = contexta;
    }
    
    public async Task<List<Utilizador>> GetAllUtilizadores()
    {
        return await _contexta.Utilizadores.ToListAsync();
    }

    public async Task<Utilizador?> GetUtilizadorById(Guid id)
    {
        var utilizador = await _contexta.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        return utilizador;
    }

    public async Task<List<Utilizador>> AddUtilizador(Utilizador utilizador)
    {
        _contexta.Utilizadores.Add(utilizador);
        await _contexta.SaveChangesAsync();
        return await _contexta.Utilizadores.ToListAsync();
    }

    public async Task<List<Utilizador>?> UpdateUtilizador(Guid id, Utilizador request)
    {
        var utilizador = await _contexta.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        
        utilizador.Email = request.Email;
        utilizador.Username = request.Username;
        utilizador.Password = request.Password;

        await _contexta.SaveChangesAsync();
        
        return await _contexta.Utilizadores.ToListAsync();
    }

    public async Task<List<Utilizador>?> DeleteUtilizador(Guid id)
    {
        var utilizador = await _contexta.Utilizadores.FindAsync(id);
        if (utilizador is null)
        {
            return null;
        }
        _contexta.Utilizadores.Remove(utilizador);
        await _contexta.SaveChangesAsync();
        return await _contexta.Utilizadores.ToListAsync();
    }
}
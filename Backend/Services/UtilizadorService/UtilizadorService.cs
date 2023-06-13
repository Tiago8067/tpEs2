using BusinessLogic.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.UtilizadorService;

public class UtilizadorService : IUtilizadorService
{
    private static List<Utilizador> _utilizadores = new List<Utilizador>
    {
        new Utilizador
        {
            Id = Guid.NewGuid(),
            Email = "soares@gmail.com", 
            Username = "soares",
            Password = "1234",
            Nome = "Tiago Soares",
            Genero = "Masculino",
            DataDeNascimento = new DateOnly(1990, 08, 30),
            CodigoPostal = "1234-123",
            Morada = "Sai do Sol",
            TipoUtilizador = "ADMIN",
            EstadoUtilizador = "ATIVO"
        },
        new Utilizador
        {
            Id = Guid.NewGuid(),
            Email = "basil@gmail.com", 
            Username = "basil",
            Password = "1234",
            Nome = "Basilio Barbosa",
            Genero = "Masculino",
            DataDeNascimento = new DateOnly(1990, 08, 30),
            CodigoPostal = "1234-123",
            Morada = "Sai do Sol",
            TipoUtilizador = "ADMIN",
            EstadoUtilizador = "ATIVO"
        }
    };

    private readonly TarefasDbContext _context;

    public UtilizadorService(TarefasDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Utilizador>> GetAllUtilizadores()
    {
        var utilizadores = await _context.Utilizadores.ToListAsync();
        return utilizadores;
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
        return _utilizadores;
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
        
        return _utilizadores;
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
        return _utilizadores;
    }
}
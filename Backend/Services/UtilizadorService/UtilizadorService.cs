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
    
    public List<Utilizador> GetAllUtilizadores()
    {
        return _utilizadores;
    }

    public Utilizador? GetUtilizadorById(Guid id)
    {
        var utilizador = _utilizadores.Find(x => x.Id == id);
        if (utilizador is null)
        {
            return null;
        }
        return utilizador;
    }

    public List<Utilizador> AddUtilizador(Utilizador utilizador)
    {
        _utilizadores.Add(utilizador);
        return _utilizadores;
    }

    public List<Utilizador>? UpdateUtilizador(Guid id, Utilizador request)
    {
        var utilizador = _utilizadores.Find(x => x.Id == id);
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
        
        return _utilizadores;
    }

    public List<Utilizador>? DeleteUtilizador(Guid id)
    {
        var utilizador = _utilizadores.Find(x => x.Id == id);
        if (utilizador is null)
        {
            return null;
        }
        _utilizadores.Remove(utilizador);
        return _utilizadores;
    }
}
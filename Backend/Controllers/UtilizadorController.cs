using BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class UtilizadorController: ControllerBase
{
    private static List<Utilizador> utilizadores = new List<Utilizador>
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
    
    [HttpGet("GetAllUtilizadores")]
    public async Task<ActionResult<List<Utilizador>>> GetAllUtilizadores()
    {
        return Ok(utilizadores);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizador>> GetUtilizadorById(Guid id)
    {
        var utilizador = utilizadores.Find(x => x.Id == id);
        if (utilizador is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(utilizador);
    }
    
    [HttpPost("AddUtilizador")]
    public async Task<ActionResult<List<Utilizador>>> AddUtilizador(Utilizador utilizador)
    {
        utilizadores.Add(utilizador);
        return Ok(utilizadores);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Utilizador>>> UpdateUtilizador(Guid id, Utilizador request)
    {
        var utilizador = utilizadores.Find(x => x.Id == id);
        if (utilizador is null)
        {
            return NotFound("Este Utilizador não Existe");
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
        
        return Ok(utilizadores);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Utilizador>>> DeleteUtilizador(Guid id)
    {
        var utilizador = utilizadores.Find(x => x.Id == id);
        if (utilizador is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        utilizadores.Remove(utilizador);
        return Ok(utilizadores);
    }

}
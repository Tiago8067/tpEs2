using Backend.Services.UtililizadorService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UtilizadorController : ControllerBase
{
    private readonly IUtilizadorService _utilizadorService;

    public UtilizadorController(IUtilizadorService utilizadorService)
    {
        _utilizadorService = utilizadorService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Utilizadore>>> GetAllUtilizadores()
    {
        return await _utilizadorService.GetAllUtilizadores();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizadore>> GetUtilizadorById(Guid id)
    {
        var result = await _utilizadorService.GetUtilizadorById(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpPost("AddUtilizador")]
    public async Task<ActionResult<List<Utilizadore>>> AddUtilizador(Utilizadore utilizador)
    {
        var result = await _utilizadorService.AddUtilizador(utilizador);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Utilizadore>>> UpdateUtilizador(Guid id, Utilizadore request)
    {
        var result = await _utilizadorService.UpdateUtilizador(id, request);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Utilizadore>>> DeleteUtilizador(Guid id)
    {
        var result = await _utilizadorService.DeleteUtilizador(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
}
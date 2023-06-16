using Backend.Services.UtililizadorService;
using BusinessLogic.Entities;
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
    public async Task<ActionResult<List<Utilizador>>> GetAllUtilizadores()
    {
        return await _utilizadorService.GetAllUtilizadores();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizador>> GetUtilizadorById(Guid id)
    {
        var result = await _utilizadorService.GetUtilizadorById(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpPost("AddUtilizador")]
    public async Task<ActionResult<List<Utilizador>>> AddUtilizador(Utilizador utilizador)
    {
        var result = await _utilizadorService.AddUtilizador(utilizador);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Utilizador>>> UpdateUtilizador(Guid id, Utilizador request)
    {
        var result = await _utilizadorService.UpdateUtilizador(id, request);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Utilizador>>> DeleteUtilizador(Guid id)
    {
        var result = await _utilizadorService.DeleteUtilizador(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
}
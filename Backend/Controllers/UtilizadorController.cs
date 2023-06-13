using Backend.Services.UtilizadorService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class UtilizadorController: ControllerBase
{
    private readonly IUtilizadorService _utilizadorService;

    public UtilizadorController(IUtilizadorService utilizadorService)
    {
        _utilizadorService = utilizadorService;
    }
    
    [HttpGet("GetAllUtilizadores")]
    public async Task<ActionResult<List<Utilizador>>> GetAllUtilizadores()
    {
        return _utilizadorService.GetAllUtilizadores();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Utilizador>> GetUtilizadorById(Guid id)
    {
        var result = _utilizadorService.GetUtilizadorById(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpPost("AddUtilizador")]
    public async Task<ActionResult<List<Utilizador>>> AddUtilizador(Utilizador utilizador)
    {
        var result = _utilizadorService.AddUtilizador(utilizador);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Utilizador>>> UpdateUtilizador(Guid id, Utilizador request)
    {
        var result = _utilizadorService.UpdateUtilizador(id, request);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Utilizador>>> DeleteUtilizador(Guid id)
    {
        var result = _utilizadorService.DeleteUtilizador(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }

}
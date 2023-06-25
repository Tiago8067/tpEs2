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
    public async Task<List<Usermodel>> GetAllUtilizadores()
    {
        return await _utilizadorService.GetAllUtilizadores();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usermodel>> GetUtilizadorById(Guid id)
    {
        var result = await _utilizadorService.GetUtilizadorById(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
    /*[HttpPost("AddUtilizador")]
    public async Task<ActionResult<List<Usermodel>>> AddUtilizador(Usermodel utilizador)
    {
        var result = await _utilizadorService.AddUtilizador(utilizador);
        return Ok(result);
    }*/
    
    [HttpPost("AddUtilizador")]
    public async Task<ActionResult<ServiceResponse<int>>> AddUtilizador(Userregisto request)
    {
        var response = await _utilizadorService.AddUtilizador(
            new Usermodel
            {
                Nome = request.Nome,
                Email = request.Email
            },
            request.Pass);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Usermodel>>> UpdateUtilizador(Guid id, Usermodel request)
    {
        var result = await _utilizadorService.UpdateUtilizador(id, request);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe, ou pode estar a Repetir o Email");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Usermodel>>> DeleteUtilizador(Guid id)
    {
        var result = await _utilizadorService.DeleteUtilizador(id);
        if (result is null)
        {
            return NotFound("Este Utilizador não Existe");
        }
        return Ok(result);
    }
    
}
using Backend.Services.ProjetoService;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjetoController : ControllerBase
{
    private readonly IProjetoService _projetoService;

    public ProjetoController(IProjetoService projetoService)
    {
        _projetoService = projetoService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Projeto>>> GetAllProjetos()
    {
        return await _projetoService.GetAllProjetos();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Projeto>> GetProjetoById(Guid id)
    {
        var result = await _projetoService.GetProjetoById(id);
        if (result is null)
        {
            return NotFound("Este Projeto não Existe");
        }
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Projeto>>> AddProjeto(Projeto projeto)
    {
        try
        {
            var result = await _projetoService.AddProjeto(projeto);
            return Ok(result);
        }
        catch (Exception e)
        {
            //Console.WriteLine(e);
            return BadRequest("Nome do projeto repetido");
            //return BadRequest();
            throw;
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Projeto>>> UpdateProjeto(Guid id, Projeto request)
    {
        var result = await _projetoService.UpdateProjeto(id, request);
        if (result is null)
        {
            return NotFound("Este Projeto não Existe");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Projeto>>> DeleteProjeto(Guid id)
    {
        var result = await _projetoService.DeleteProjeto(id);
        if (result is null)
        {
            return NotFound("Este Projeto não Existe");
        }
        return Ok(result);
    }
}
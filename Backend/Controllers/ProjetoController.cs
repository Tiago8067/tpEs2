using Backend.Services.ProjetoService;
using BusinessLogic.Entities;
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
        var result = await _projetoService.AddProjeto(projeto);
        return Ok(result);
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
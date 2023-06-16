using Backend.Services.TarefaService;
using BusinessLogic.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Tarefa>>> GetAllTarefas()
    {
        return await _tarefaService.GetAllTarefas();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarefa>> GetTarefaById(Guid id)
    {
        var result = await _tarefaService.GetTarefaById(id);
        if (result is null)
        {
            return NotFound("Esta Tarefa não Existe");
        }
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<List<Tarefa>>> AddTarefa(Tarefa tarefa)
    {
        var result = await _tarefaService.AddTarefa(tarefa);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<Tarefa>>> UpdateTarefa(Guid id, Tarefa request)
    {
        var result = await _tarefaService.UpdateTarefa(id, request);
        if (result is null)
        {
            return NotFound("Esta Tarefa não Existe");
        }
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Tarefa>>> DeleteTarefa(Guid id)
    {
        var result = await _tarefaService.DeleteTarefa(id);
        if (result is null)
        {
            return NotFound("Esta Tarefa não Existe");
        }
        return Ok(result);
    }
}
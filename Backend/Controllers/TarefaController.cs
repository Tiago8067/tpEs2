using Backend.Services.TarefaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;

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

    [HttpPut("{tarefaId}/associate-projeto/{nomeProj}")]
    public async Task<ActionResult<List<Tarefa>>> AssociateTarefaProjeto(Guid tarefaId, String nomeProj)
    {
        Console.WriteLine("entrou");
        var result = await _tarefaService.AssociateTarefaProjeto(tarefaId, nomeProj);
        if (result is null)
        {
            return NotFound("A tarefa ou o projeto não existem");
        }
        
        SqlCommand cmd = new SqlCommand("UPDATE projetos p SET nome = nomeProj FROM tarefas t WHERE  p.id = t.projeto_id;");
        Console.WriteLine("saiu controller");
        return Ok(result);
    }
    
    [HttpPut("tarefas/{tarefaId}/associar/{nomeProj}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AssociarTarefaProjeto(Guid tarefaId, String nomeProj)
    {
        var tarefa = _tarefaService.AssociarTarefaProjeto(tarefaId, nomeProj);

        if (tarefa != null)
        {
            return Ok(tarefa);
        }
        else
        {
            return NotFound();
        }
    }


}
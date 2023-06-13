using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Context;
using BusinessLogic.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadoresController : ControllerBase
    {
        private readonly TarefasProjetosDbContext _context;

        public UtilizadoresController(TarefasProjetosDbContext context)
        {
            _context = context;
        }

        // GET: api/Utilizadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetUtilizadores()
        {
            if (_context.Utilizadores == null)
            {
                return NotFound();
            }

            return await _context
                .Utilizadores.Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.Username,
                    u.Password,
                    u.Nome,
                    u.Genero,
                    u.DataDeNascimento,
                    u.CodigoPostal,
                    u.Morada,
                    u.TipoUtilizador,
                    u.EstadoUtilizador,
                    u.Projetos
                    //Como ir buscar dados associados
                    //Books = u.Books.Select(b => new
                    //{
                    //    b.Id,
                    //    b.Title,
                    //    b.Status,
                    //    b.PublicationYear
                    //})
                }).ToListAsync();
        }

        // GET: api/Utilizadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilizador>> GetUtilizador(Guid id)
        {
            if (_context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);

            if (utilizador == null)
            {
                return NotFound();
            }

            return utilizador;
        }

        // PUT: api/Utilizadores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilizador(Guid id, Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return BadRequest();
            }

            _context.Entry(utilizador).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilizadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Utilizadores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Utilizador>> PostUtilizador(Utilizador utilizador)
        {
            if (_context.Utilizadores == null)
            {
                return Problem("Entity set 'ES2DbContext.Utilizadores'  is null.");
            }

            _context.Utilizadores.Add(utilizador);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUtilizador", new { id = utilizador.Id }, utilizador);
        }

        // DELETE: api/Utilizadores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilizador(Guid id)
        {
            if (_context.Utilizadores == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _context.Utilizadores.Remove(utilizador);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilizadorExists(Guid id)
        {
            return (_context.Utilizadores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
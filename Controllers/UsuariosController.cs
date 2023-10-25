using Stefanini_Project01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Stefanini_Project01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext _dbContext;

        public UsuariosController(UsuarioContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }
            return await _dbContext.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }
            var usuario = await _dbContext.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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
        private bool UsuarioExists(long id)
        {
            return (_dbContext.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (_dbContext.Usuarios == null)
            {
                return NotFound();
            }

            var movie = await _dbContext.Usuarios.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            _dbContext.Usuarios.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

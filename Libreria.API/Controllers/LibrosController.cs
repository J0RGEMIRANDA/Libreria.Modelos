using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Modelos;

namespace Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
        {
            var data = await _context.Libros
                .Include(l => l.Pais)
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .ToListAsync();

            return data;
        }

        // GET: api/Libros
        [HttpGet("Editorial/{id}")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosByEditorial(int id) 
        {
            var data = await _context.Libros
                .Where(l => l.EditorialCodigo == id)
                .Include(l => l.Pais)
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .ToListAsync();

            return data;

        }

        // GET: api/Libros
        [HttpGet("autor/{id}")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibrosByAutor(int id)
        {
            var data = await _context.Libros
                .Where(l => l.AutorCodigo == id)
                .Include(l => l.Pais)
                .Include(l => l.Autor)
                .Include(l => l.Editorial)
                .ToListAsync();

            return data;

        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            if (id != libro.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Codigo }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Codigo == id);
        }
    }
}

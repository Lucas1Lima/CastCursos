using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CastCursosAPI.Models;

namespace CastCursosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly CursoContext _context;

        public CursosController(CursoContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // PUT: api/Cursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.ID)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursoExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            bool a = _context.Cursos.Any(c => c.Descricao.ToLower().Trim().Equals(curso.Descricao.ToLower().Trim()));
            bool b = _context.Cursos.Any(dti => (dti.DataInicio.Date < curso.DataFinal.Date) && (curso.DataInicio.Date < dti.DataFinal.Date));
            

            if (a)
            {
                return BadRequest();
            }
            else
            {
                if (b)
                {
                    return NotFound();
                }
                else
                {
                    if (curso.DataInicio < DateTime.Now)
                    {
                        return Unauthorized(); 
                    }
                    else
                    {
                        _context.Cursos.Add(curso);
                        await _context.SaveChangesAsync();
                    }
                }
            }




            return CreatedAtAction("GetCurso", new { id = curso.ID }, curso);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            if (curso.DataFinal < DateTime.Now)
            {
                return BadRequest();
            }
            else
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.ID == id);
        }
    }
}

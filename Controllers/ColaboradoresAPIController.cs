using appbeneficiencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresAPIController : ControllerBase
    {
        private readonly BeneficiariosdbContext _context;

        public ColaboradoresAPIController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: api/ColaboradoresAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colaboradore>>> GetColaboradores()
        {
            if (_context.Colaboradores == null)
            {
                return NotFound();
            }
            return await _context.Colaboradores.ToListAsync();
        }

        // GET: api/ColaboradoresAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colaboradore>> GetColaboradore(int id)
        {
            if (_context.Colaboradores == null)
            {
                return NotFound();
            }
            var colaboradore = await _context.Colaboradores.FindAsync(id);

            if (colaboradore == null)
            {
                return NotFound();
            }

            return colaboradore;
        }

        // PUT: api/ColaboradoresAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColaboradore(int id, Colaboradore colaboradore)
        {
            if (id != colaboradore.IdColaborador)
            {
                return BadRequest();
            }

            _context.Entry(colaboradore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradoreExists(id))
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

        // POST: api/ColaboradoresAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Colaboradore>> PostColaboradore(Colaboradore colaboradore)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Colaboradores'  is null.");
            }
            _context.Colaboradores.Add(colaboradore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColaboradore", new { id = colaboradore.IdColaborador }, colaboradore);
        }

        // DELETE: api/ColaboradoresAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColaboradore(int id)
        {
            if (_context.Colaboradores == null)
            {
                return NotFound();
            }
            var colaboradore = await _context.Colaboradores.FindAsync(id);
            if (colaboradore == null)
            {
                return NotFound();
            }

            _context.Colaboradores.Remove(colaboradore);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColaboradoreExists(int id)
        {
            return (_context.Colaboradores?.Any(e => e.IdColaborador == id)).GetValueOrDefault();
        }
    }
}

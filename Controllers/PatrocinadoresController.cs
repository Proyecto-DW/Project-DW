using appbeneficiencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//Creación del Controlador Patrocinadores
namespace appbeneficiencia.Controllers
{
    public class PatrocinadoresController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public PatrocinadoresController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Patrocinadores
        public async Task<IActionResult> Index()
        {
            return _context.Patrocinadores != null ?
                        View(await _context.Patrocinadores.ToListAsync()) :
                        Problem("Entity set 'BeneficiariosdbContext.Patrocinadores'  is null.");
        }

        // GET: Patrocinadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patrocinadores == null)
            {
                return NotFound();
            }

            var patrocinadore = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.IdPatrocinador == id);
            if (patrocinadore == null)
            {
                return NotFound();
            }

            return View(patrocinadore);
        }

        // GET: Patrocinadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Patrocinadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPatrocinador,CodigoReferencia,CodigoPais,Estado,FechaRegistro")] Patrocinadore patrocinadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patrocinadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinadore);
        }

        // GET: Patrocinadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patrocinadores == null)
            {
                return NotFound();
            }

            var patrocinadore = await _context.Patrocinadores.FindAsync(id);
            if (patrocinadore == null)
            {
                return NotFound();
            }
            return View(patrocinadore);
        }

        // POST: Patrocinadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPatrocinador,CodigoReferencia,CodigoPais,Estado,FechaRegistro")] Patrocinadore patrocinadore)
        {
            if (id != patrocinadore.IdPatrocinador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patrocinadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatrocinadoreExists(patrocinadore.IdPatrocinador))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(patrocinadore);
        }

        // GET: Patrocinadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Patrocinadores == null)
            {
                return NotFound();
            }

            var patrocinadore = await _context.Patrocinadores
                .FirstOrDefaultAsync(m => m.IdPatrocinador == id);
            if (patrocinadore == null)
            {
                return NotFound();
            }

            return View(patrocinadore);
        }

        // POST: Patrocinadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Patrocinadores == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Patrocinadores'  is null.");
            }
            var patrocinadore = await _context.Patrocinadores.FindAsync(id);
            if (patrocinadore != null)
            {
                _context.Patrocinadores.Remove(patrocinadore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatrocinadoreExists(int id)
        {
            return (_context.Patrocinadores?.Any(e => e.IdPatrocinador == id)).GetValueOrDefault();
        }
    }
}

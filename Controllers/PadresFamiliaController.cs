using appbeneficiencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    public class PadresFamiliaController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public PadresFamiliaController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: PadresFamilia
        public async Task<IActionResult> Index()
        {
            return _context.PadresDeFamilia != null ?
                        View(await _context.PadresDeFamilia.ToListAsync()) :
                        Problem("Entity set 'BeneficiariosdbContext.PadresDeFamilia'  is null.");
        }

        // GET: PadresFamilia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PadresDeFamilia == null)
            {
                return NotFound();
            }

            var padresDeFamilium = await _context.PadresDeFamilia
                .FirstOrDefaultAsync(m => m.IdPadre == id);
            if (padresDeFamilium == null)
            {
                return NotFound();
            }

            return View(padresDeFamilium);
        }

        // GET: PadresFamilia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadresFamilia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPadre,Dpipadre,NombreCompletoPadre,TelefonoPadre,Dpimadre,NombreCompletoMadre,TelefonoMadre,DireccionPrincipal,DireccionSecundaria")] PadresDeFamilium padresDeFamilium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padresDeFamilium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padresDeFamilium);
        }

        // GET: PadresFamilia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PadresDeFamilia == null)
            {
                return NotFound();
            }

            var padresDeFamilium = await _context.PadresDeFamilia.FindAsync(id);
            if (padresDeFamilium == null)
            {
                return NotFound();
            }
            return View(padresDeFamilium);
        }

        // POST: PadresFamilia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPadre,Dpipadre,NombreCompletoPadre,TelefonoPadre,Dpimadre,NombreCompletoMadre,TelefonoMadre,DireccionPrincipal,DireccionSecundaria")] PadresDeFamilium padresDeFamilium)
        {
            if (id != padresDeFamilium.IdPadre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padresDeFamilium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadresDeFamiliumExists(padresDeFamilium.IdPadre))
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
            return View(padresDeFamilium);
        }

        // GET: PadresFamilia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PadresDeFamilia == null)
            {
                return NotFound();
            }

            var padresDeFamilium = await _context.PadresDeFamilia
                .FirstOrDefaultAsync(m => m.IdPadre == id);
            if (padresDeFamilium == null)
            {
                return NotFound();
            }

            return View(padresDeFamilium);
        }

        // POST: PadresFamilia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PadresDeFamilia == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.PadresDeFamilia'  is null.");
            }
            var padresDeFamilium = await _context.PadresDeFamilia.FindAsync(id);
            if (padresDeFamilium != null)
            {
                _context.PadresDeFamilia.Remove(padresDeFamilium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadresDeFamiliumExists(int id)
        {
            return (_context.PadresDeFamilia?.Any(e => e.IdPadre == id)).GetValueOrDefault();
        }
    }
}

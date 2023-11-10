using appbeneficiencia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    [Authorize]
    public class ColaboradoresController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public ColaboradoresController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
            var beneficiariosdbContext = _context.Colaboradores.Include(c => c.IdPuestoNavigation);
            return View(await beneficiariosdbContext.ToListAsync());
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores
                .Include(c => c.IdPuestoNavigation)
                .FirstOrDefaultAsync(m => m.IdColaborador == id);
            if (colaboradore == null)
            {
                return NotFound();
            }

            return View(colaboradore);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            ViewData["IdPuesto"] = new SelectList(_context.Puestos, "IdPuesto", "NombrePuesto");
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdColaborador,NombreCompleto,Profesion,Dpi,Correo,Direccion,Telefono,FechaNacimiento,Genero,IdPuesto")] Colaboradore colaboradore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPuesto"] = new SelectList(_context.Puestos, "IdPuesto", "NombrePuesto", colaboradore.IdPuesto);
            return View(colaboradore);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores.FindAsync(id);
            if (colaboradore == null)
            {
                return NotFound();
            }
            ViewData["IdPuesto"] = new SelectList(_context.Puestos, "IdPuesto", "NombrePuesto", colaboradore.IdPuesto);
            return View(colaboradore);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdColaborador,NombreCompleto,Profesion,Dpi,Correo,Direccion,Telefono,FechaNacimiento,Genero,IdPuesto")] Colaboradore colaboradore)
        {
            if (id != colaboradore.IdColaborador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoreExists(colaboradore.IdColaborador))
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
            ViewData["IdPuesto"] = new SelectList(_context.Puestos, "IdPuesto", "NombrePuesto", colaboradore.IdPuesto);
            return View(colaboradore);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores
                .Include(c => c.IdPuestoNavigation)
                .FirstOrDefaultAsync(m => m.IdColaborador == id);
            if (colaboradore == null)
            {
                return NotFound();
            }

            return View(colaboradore);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Colaboradores'  is null.");
            }
            var colaboradore = await _context.Colaboradores.FindAsync(id);
            if (colaboradore != null)
            {
                _context.Colaboradores.Remove(colaboradore);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoreExists(int id)
        {
            return (_context.Colaboradores?.Any(e => e.IdColaborador == id)).GetValueOrDefault();
        }
    }
}

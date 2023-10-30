using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appbeneficiencia.Models;
using Microsoft.Data.SqlClient;

namespace appbeneficiencia.Controllers
{
    public class BeneficiariosController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public BeneficiariosController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Beneficiarios
        public async Task<IActionResult> Index()
        {
            var beneficiariosdbContext = _context.Beneficiarios.Include(b => b.IdColaboradorNavigation).Include(b => b.IdPadreNavigation);
            return View(await beneficiariosdbContext.ToListAsync());
        }

        // GET: Beneficiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .Include(b => b.IdColaboradorNavigation)
                .Include(b => b.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // GET: Beneficiarios/Create
        public IActionResult Create()
        {
            ViewBag.IdColaborador = new SelectList(_context.Colaboradores, "IdColaborador", "NombreCompleto"); // Cambié "IdColaborador" a "NombreCompleto" para mostrar los nombres en lugar de identificadores
            ViewBag.IdPadre = new SelectList(_context.PadresDeFamilia, "IdPadre", "NombreCompletoPadre"); // Cambié "IdPadre" a "NombreCompletoPadre" para mostrar los nombres en lugar de identificadores
            return View();
        }

        // POST: Beneficiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBeneficiario,NombreCompleto,FechaNacimiento,Genero,Direccion,CodigoBeneficiario,Nivel,Telefono,IdPadre,Estado,IdColaborador")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColaborador"] = new SelectList(_context.Colaboradores, "IdColaborador", "IdColaborador", beneficiario.IdColaborador);
            ViewData["IdPadre"] = new SelectList(_context.PadresDeFamilia, "IdPadre", "IdPadre", beneficiario.IdPadre);
            return View(beneficiario);
        }

        // GET: Beneficiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            ViewBag.IdColaborador = new SelectList(_context.Colaboradores, "IdColaborador", "NombreCompleto");
            ViewBag.IdPadre = new SelectList(_context.PadresDeFamilia, "IdPadre", "NombreCompletoPadre");

            return View(beneficiario);
        }

        // POST: Beneficiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBeneficiario,NombreCompleto,FechaNacimiento,Genero,Direccion,CodigoBeneficiario,Nivel,Telefono,IdPadre,Estado,IdColaborador")] Beneficiario beneficiario)
        {
            if (id != beneficiario.IdBeneficiario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficiario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficiarioExists(beneficiario.IdBeneficiario))
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
            ViewData["IdColaborador"] = new SelectList(_context.Colaboradores, "IdColaborador", "IdColaborador", beneficiario.IdColaborador);
            ViewData["IdPadre"] = new SelectList(_context.PadresDeFamilia, "IdPadre", "IdPadre", beneficiario.IdPadre);
            return View(beneficiario);
        }

        // GET: Beneficiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Beneficiarios == null)
            {
                return NotFound();
            }

            var beneficiario = await _context.Beneficiarios
                .Include(b => b.IdColaboradorNavigation)
                .Include(b => b.IdPadreNavigation)
                .FirstOrDefaultAsync(m => m.IdBeneficiario == id);
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // POST: Beneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Beneficiarios == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Beneficiarios'  is null.");
            }
            var beneficiario = await _context.Beneficiarios.FindAsync(id);
            if (beneficiario != null)
            {
                _context.Beneficiarios.Remove(beneficiario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //METODO QUE PERMITE CALCULAR A LOS NIÑOS QUE ESTAN POR CUMPLIR AÑOS
        public async Task<IActionResult> BeneficiariosCumplenAnios()
        {
            // Obtén la fecha actual
            var fechaActual = DateTime.Today;

            // Construye una consulta SQL personalizada para obtener beneficiarios por trimestre
            var sqlQuery = "SELECT * FROM Beneficiarios " +
                           "WHERE DATEPART(quarter, FechaNacimiento) = DATEPART(quarter, @FechaActual)";

            var beneficiariosCumplenAnios = await _context.Beneficiarios
                .FromSqlRaw(sqlQuery, new SqlParameter("FechaActual", fechaActual))
                .ToListAsync();

            return View(beneficiariosCumplenAnios);
        }



        private bool BeneficiarioExists(int id)
        {
          return (_context.Beneficiarios?.Any(e => e.IdBeneficiario == id)).GetValueOrDefault();
        }
    }
}

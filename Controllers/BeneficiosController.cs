﻿using appbeneficiencia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    public class BeneficiosController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public BeneficiosController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Beneficios
        public async Task<IActionResult> Index()
        {
            return _context.Beneficios != null ?
                        View(await _context.Beneficios.ToListAsync()) :
                        Problem("Entity set 'BeneficiariosdbContext.Beneficios'  is null.");
        }

        // GET: Beneficios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios
                .FirstOrDefaultAsync(m => m.IdBeneficio == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // GET: Beneficios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beneficios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBeneficio,Nombre,Descripcion")] Beneficio beneficio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beneficio);
        }

        // GET: Beneficios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio == null)
            {
                return NotFound();
            }
            return View(beneficio);
        }

        // POST: Beneficios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBeneficio,Nombre,Descripcion")] Beneficio beneficio)
        {
            if (id != beneficio.IdBeneficio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beneficio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeneficioExists(beneficio.IdBeneficio))
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
            return View(beneficio);
        }

        // GET: Beneficios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Beneficios == null)
            {
                return NotFound();
            }

            var beneficio = await _context.Beneficios
                .FirstOrDefaultAsync(m => m.IdBeneficio == id);
            if (beneficio == null)
            {
                return NotFound();
            }

            return View(beneficio);
        }

        // POST: Beneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Beneficios == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Beneficios'  is null.");
            }
            var beneficio = await _context.Beneficios.FindAsync(id);
            if (beneficio != null)
            {
                _context.Beneficios.Remove(beneficio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeneficioExists(int id)
        {
            return (_context.Beneficios?.Any(e => e.IdBeneficio == id)).GetValueOrDefault();
        }
    }
}

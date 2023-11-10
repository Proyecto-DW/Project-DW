using appbeneficiencia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    [Authorize]
    public class BeneficiariosController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public BeneficiariosController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Beneficiarios
        public async Task<IActionResult> Index(string searchString)
        {
            var beneficiarios = from b in _context.Beneficiarios
                                select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                beneficiarios = beneficiarios.Where(b =>
                    b.NombreCompleto.Contains(searchString) ||
                    b.CodigoBeneficiario.Contains(searchString) ||
                    b.Nivel.Contains(searchString)
                );
            }

            return View(await beneficiarios.ToListAsync());
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
            ViewData["IdColaborador"] = new SelectList(_context.Colaboradores, "IdColaborador", "NombreCompleto");
            return View();
        }

        // POST: Beneficiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBeneficiario,NombreCompleto,FechaNacimiento,Edad,Genero,Direccion,TelefonoBeneficiario,CodigoBeneficiario,Nivel,NombrePadre,Dpipadre,TelefonoPadre,DireccionPadre,NombreMadre,Dpimadre,TelefonoMadre,DireccionMadre,TelefonoPrincipal,TelefonoSecundario,IdColaborador,Estado")] Beneficiario beneficiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beneficiario);
                await _context.SaveChangesAsync();

                // Guardar mensaje en TempData
                TempData["ExitoMensaje"] = "Beneficiario creado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColaborador"] = new SelectList(_context.Colaboradores, "IdColaborador", "NombreCompleto", beneficiario.IdColaborador);
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
            ViewData["IdColaborador"] = new SelectList(_context.Colaboradores, "IdColaborador", "NombreCompleto", beneficiario.IdColaborador);
            return View(beneficiario);
        }

        // POST: Beneficiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBeneficiario,NombreCompleto,FechaNacimiento,Edad,Genero,Direccion,TelefonoBeneficiario,CodigoBeneficiario,Nivel,NombrePadre,Dpipadre,TelefonoPadre,DireccionPadre,NombreMadre,Dpimadre,TelefonoMadre,DireccionMadre,TelefonoPrincipal,TelefonoSecundario,IdColaborador,Estado")] Beneficiario beneficiario)
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
            var sqlQuery = "SELECT * FROM Beneficiario " +
                           "WHERE DATEPART(quarter, FechaNacimiento) = DATEPART(quarter, @FechaActual)";

            var beneficiariosCumplenAnios = await _context.Beneficiarios
                .FromSqlRaw(sqlQuery, new SqlParameter("FechaActual", fechaActual))
                .ToListAsync();

            return View(beneficiariosCumplenAnios);
        }

        //Promocion Estudiantes
        public async Task<IActionResult> PromoverBeneficiarios()
        {
            var beneficiarios = await _context.Beneficiarios.ToListAsync();

            foreach (var beneficiario in beneficiarios)
            {
                var fechaNacimiento = beneficiario.FechaNacimiento;
                var hoy = DateTime.Today;
                var edad = hoy.Year - fechaNacimiento.Year;

                if (hoy < fechaNacimiento.AddYears(edad))
                {
                    edad--;
                }

                // Asignar el nuevo nivel basado en la edad
                string nuevoNivel = ObtenerNivel(edad); // Método para obtener el nivel basado en la edad

                // Actualizar el nivel del beneficiario
                beneficiario.Nivel = nuevoNivel;
                _context.Update(beneficiario);
            }

            // Guardar cambios en la base de datos
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private string ObtenerNivel(int edad)
        {
            // Lógica para asignar el nivel basado en la edad
            if (edad >= 3 && edad <= 5)
            {
                return "NIVEL 1";
            }
            else if (edad >= 6 && edad <= 8)
            {
                return "NIVEL 2";
            }
            else if (edad >= 9 && edad <= 11)
            {
                return "NIVEL 3";
            }
            else if (edad >= 12 && edad <= 14)
            {
                return "NIVEL 4";
            }
            else if (edad >= 15 && edad <= 18)
            {
                return "NIVEL 5";
            }
            // En caso de no cumplir con ningún rango, podrías retornar un valor por defecto o manejarlo según tu lógica
            return "NO APLICA";
        }





        private bool BeneficiarioExists(int id)
        {
            return (_context.Beneficiarios?.Any(e => e.IdBeneficiario == id)).GetValueOrDefault();
        }
    }
}

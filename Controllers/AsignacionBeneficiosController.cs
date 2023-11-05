using appbeneficiencia.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace appbeneficiencia.Controllers
{
    public class AsignacionBeneficiosController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public AsignacionBeneficiosController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: AsignacionBeneficios
        public async Task<IActionResult> Index()
        {
            var beneficiariosdbContext = _context.AsignacionBeneficios.Include(a => a.IdBeneficiarioNavigation).Include(a => a.IdBeneficioNavigation);
            return View(await beneficiariosdbContext.ToListAsync());
        }

        // GET: AsignacionBeneficios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AsignacionBeneficios == null)
            { //hola
                return NotFound();
            }

            var asignacionBeneficio = await _context.AsignacionBeneficios
                .Include(a => a.IdBeneficiarioNavigation)
                .Include(a => a.IdBeneficioNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionBeneficio == null)
            {
                return NotFound();
            }

            return View(asignacionBeneficio);
        }

        // GET: AsignacionBeneficios/Create
        public IActionResult Create()
        {
            ViewData["IdBeneficiario"] = new SelectList(_context.Beneficiarios, "IdBeneficiario", "NombreCompleto");
            ViewData["IdBeneficio"] = new SelectList(_context.Beneficios, "IdBeneficio", "Nombre");
            return View();
        }

        // POST: AsignacionBeneficios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,IdBeneficiario,IdBeneficio,DescripcionBeneficio,FechaAsignacion,Monto,Dpi,Parentesco,Comentarios")] AsignacionBeneficio asignacionBeneficio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionBeneficio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBeneficiario"] = new SelectList(_context.Beneficiarios, "IdBeneficiario", "NombreCompleto", asignacionBeneficio.IdBeneficiario);
            ViewData["IdBeneficio"] = new SelectList(_context.Beneficios, "IdBeneficio", "Nombre", asignacionBeneficio.IdBeneficio);
            return View(asignacionBeneficio);
        }

        // GET: AsignacionBeneficios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AsignacionBeneficios == null)
            {
                return NotFound();
            }

            var asignacionBeneficio = await _context.AsignacionBeneficios.FindAsync(id);
            if (asignacionBeneficio == null)
            {
                return NotFound();
            }
            ViewData["IdBeneficiario"] = new SelectList(_context.Beneficiarios, "IdBeneficiario", "NombreCompleto", asignacionBeneficio.IdBeneficiario);
            ViewData["IdBeneficio"] = new SelectList(_context.Beneficios, "IdBeneficio", "Nombre", asignacionBeneficio.IdBeneficio);
            return View(asignacionBeneficio);
        }

        // POST: AsignacionBeneficios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,IdBeneficiario,IdBeneficio,DescripcionBeneficio,FechaAsignacion,Monto,Dpi,Parentesco,Comentarios")] AsignacionBeneficio asignacionBeneficio)
        {
            if (id != asignacionBeneficio.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionBeneficio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionBeneficioExists(asignacionBeneficio.IdAsignacion))
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
            ViewData["IdBeneficiario"] = new SelectList(_context.Beneficiarios, "IdBeneficiario", "NombreCompleto", asignacionBeneficio.IdBeneficiario);
            ViewData["IdBeneficio"] = new SelectList(_context.Beneficios, "IdBeneficio", "Nombre", asignacionBeneficio.IdBeneficio);
            return View(asignacionBeneficio);
        }

        // GET: AsignacionBeneficios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AsignacionBeneficios == null)
            {
                return NotFound();
            }

            var asignacionBeneficio = await _context.AsignacionBeneficios
                .Include(a => a.IdBeneficiarioNavigation)
                .Include(a => a.IdBeneficioNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionBeneficio == null)
            {
                return NotFound();
            }

            return View(asignacionBeneficio);
        }

        // POST: AsignacionBeneficios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AsignacionBeneficios == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.AsignacionBeneficios'  is null.");
            }
            var asignacionBeneficio = await _context.AsignacionBeneficios.FindAsync(id);
            if (asignacionBeneficio != null)
            {
                _context.AsignacionBeneficios.Remove(asignacionBeneficio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //REPORTE EXCEL
        public IActionResult ExportToExcel()
        {
            var asignaciones = _context.AsignacionBeneficios
                .Include(a => a.IdBeneficiarioNavigation)
                .Include(a => a.IdBeneficioNavigation)
                .ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Asignaciones");

                worksheet.Cell(1, 1).Value = "Beneficiario";
                worksheet.Cell(1, 2).Value = "Cod. Beneficiario";
                worksheet.Cell(1, 3).Value = "Nivel";
                worksheet.Cell(1, 4).Value = "Edad";
                worksheet.Cell(1, 5).Value = "Beneficio";
                worksheet.Cell(1, 6).Value = "Descripción";
                worksheet.Cell(1, 7).Value = "Monto Recibido";
                worksheet.Cell(1, 8).Value = "DPI Recibe";
                worksheet.Cell(1, 9).Value = "Parentesco";
                worksheet.Cell(1, 10).Value = "Fecha Asig.";
                // ... Agregar más encabezados según tus campos

                int row = 2;
                foreach (var asignacion in asignaciones)
                {
                    worksheet.Cell(row, 1).Value = asignacion.IdBeneficiarioNavigation?.NombreCompleto;
                    worksheet.Cell(row, 2).Value = asignacion.IdBeneficiarioNavigation?.CodigoBeneficiario;
                    worksheet.Cell(row, 3).Value = asignacion.IdBeneficiarioNavigation?.Edad;
                    worksheet.Cell(row, 4).Value = asignacion.IdBeneficiarioNavigation?.Nivel;
                    worksheet.Cell(row, 5).Value = asignacion.IdBeneficioNavigation?.Nombre;
                    worksheet.Cell(row, 6).Value = asignacion.DescripcionBeneficio;
                    worksheet.Cell(row, 7).Value = asignacion.Monto;
                    worksheet.Cell(row, 8).Value = asignacion.Dpi;
                    worksheet.Cell(row, 9).Value = asignacion.Parentesco;
                    worksheet.Cell(row, 10).Value = asignacion.FechaAsignacion;
                    // ... Agregar más celdas según tus campos

                    row++;
                }

                byte[] fileContents;
                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    fileContents = stream.ToArray();
                }

                string fileName = "ReporteAsignaciones.xlsx";

                return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }


        private bool AsignacionBeneficioExists(int id)
        {
            return (_context.AsignacionBeneficios?.Any(e => e.IdAsignacion == id)).GetValueOrDefault();
        }
    }
}

﻿using appbeneficiencia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace appbeneficiencia.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly BeneficiariosdbContext _context;

        public UsuariosController(BeneficiariosdbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var beneficiariosdbContext = _context.Usuarios.Include(u => u.IdRolNavigation);
            return View(await beneficiariosdbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles, "IdRol", "Nombre"); // Cambiar "Nombre" al nombre de la propiedad que contiene el nombre del rol
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NombreUsuario,Correo,Clave,Estado,IdRol")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Cifra la contraseña antes de guardarla en la base de datos
                if (!string.IsNullOrEmpty(usuario.Clave))
                {
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(usuario.Clave));
                        usuario.Clave = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                    }
                }

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.IdRol);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", usuario.IdRol);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NombreUsuario,Correo,Clave,Estado,IdRol")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica si la contraseña se ha modificado
                    var existingUsuario = _context.Usuarios.AsNoTracking().FirstOrDefault(u => u.IdUsuario == usuario.IdUsuario);
                    if (existingUsuario != null && usuario.Clave != existingUsuario.Clave)
                    {
                        // Cifra la nueva contraseña antes de guardarla en la base de datos
                        using (SHA256 sha256 = SHA256.Create())
                        {
                            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(usuario.Clave));
                            usuario.Clave = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                        }
                    }

                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", usuario.IdRol);
            return View(usuario);
        }


        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'BeneficiariosdbContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}


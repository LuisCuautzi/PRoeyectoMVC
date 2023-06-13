using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gen06_23_AutosMVC.Models;

namespace Gen06_23_AutosMVC.Controllers
{
    public class RentumsController : Controller
    {
        private readonly Gen06_23_MCVContext _context;

        public RentumsController(Gen06_23_MCVContext context)
        {
            _context = context;
        }

        // GET: Rentums
        public async Task<IActionResult> Index()
        {
            var gen06_23_MCVContext = _context.Renta.Include(r => r.Auto).Include(r => r.Perfil).Include(r => r.StatusRenta);
            return View(await gen06_23_MCVContext.ToListAsync());
        }

        // GET: Rentums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Renta == null)
            {
                return NotFound();
            }

            var rentum = await _context.Renta
                .Include(r => r.Auto)
                .Include(r => r.Perfil)
                .Include(r => r.StatusRenta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentum == null)
            {
                return NotFound();
            }

            return View(rentum);
        }

        // GET: Rentums/Create
        public IActionResult Create()
        {
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Modelo");
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion");
            ViewData["StatusRentaId"] = new SelectList(_context.StatusRenta, "Id", "Descripcion");
            return View();
        }

        // POST: Rentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaInicio,FechaFin,DatosPersonalesId,PerfilId,AutoId,StatusRentaId")] Rentum rentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", rentum.AutoId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", rentum.PerfilId);
            ViewData["StatusRentaId"] = new SelectList(_context.StatusRenta, "Id", "Descripcion", rentum.StatusRentaId);
            return View(rentum);
        }

        // GET: Rentums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Renta == null)
            {
                return NotFound();
            }

            var rentum = await _context.Renta.FindAsync(id);
            if (rentum == null)
            {
                return NotFound();
            }
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", rentum.AutoId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", rentum.PerfilId);
            ViewData["StatusRentaId"] = new SelectList(_context.StatusRenta, "Id", "Descripcion", rentum.StatusRentaId);
            return View(rentum);
        }

        // POST: Rentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaInicio,FechaFin,DatosPersonalesId,PerfilId,AutoId,StatusRentaId")] Rentum rentum)
        {
            if (id != rentum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentumExists(rentum.Id))
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
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", rentum.AutoId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", rentum.PerfilId);
            ViewData["StatusRentaId"] = new SelectList(_context.StatusRenta, "Id", "Descripcion", rentum.StatusRentaId);
            return View(rentum);
        }

        // GET: Rentums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Renta == null)
            {
                return NotFound();
            }

            var rentum = await _context.Renta
                .Include(r => r.Auto)
                .Include(r => r.Perfil)
                .Include(r => r.StatusRenta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rentum == null)
            {
                return NotFound();
            }

            return View(rentum);
        }

        // POST: Rentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Renta == null)
            {
                return Problem("Entity set 'Gen06_23_MCVContext.Renta'  is null.");
            }
            var rentum = await _context.Renta.FindAsync(id);
            if (rentum != null)
            {
                _context.Renta.Remove(rentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentumExists(int id)
        {
          return _context.Renta.Any(e => e.Id == id);
        }
    }
}

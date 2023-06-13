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
    public class PagoesController : Controller
    {
        private readonly Gen06_23_MCVContext _context;

        public PagoesController(Gen06_23_MCVContext context)
        {
            _context = context;
        }

        // GET: Pagoes
        public async Task<IActionResult> Index()
        {
            var gen06_23_MCVContext = _context.Pagos.Include(p => p.Auto).Include(p => p.CostoAdicional).Include(p => p.Perfil).Include(p => p.StatusPago).Include(p => p.TipoPago);
            return View(await gen06_23_MCVContext.ToListAsync());
        }

        // GET: Pagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Auto)
                .Include(p => p.CostoAdicional)
                .Include(p => p.Perfil)
                .Include(p => p.StatusPago)
                .Include(p => p.TipoPago)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // GET: Pagoes/Create
        public IActionResult Create()
        {
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color");
            ViewData["CostoAdicionalId"] = new SelectList(_context.CostoAdicionals, "Id", "MontoAdicional");
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion");
            ViewData["StatusPagoId"] = new SelectList(_context.StatusPagos, "Id", "Descripcion");
            ViewData["TipoPagoId"] = new SelectList(_context.TipoPagos, "Id", "Descripcion");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,NumPago,PerfilId,AutoId,StatusPagoId,CostoAdicionalId,TipoPagoId")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", pago.AutoId);
            ViewData["CostoAdicionalId"] = new SelectList(_context.CostoAdicionals, "Id", "MontoAdicional", pago.CostoAdicionalId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", pago.PerfilId);
            ViewData["StatusPagoId"] = new SelectList(_context.StatusPagos, "Id", "Descripcion", pago.StatusPagoId);
            ViewData["TipoPagoId"] = new SelectList(_context.TipoPagos, "Id", "Descripcion", pago.TipoPagoId);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FindAsync(id);
            if (pago == null)
            {
                return NotFound();
            }
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", pago.AutoId);
            ViewData["CostoAdicionalId"] = new SelectList(_context.CostoAdicionals, "Id", "MontoAdicional", pago.CostoAdicionalId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", pago.PerfilId);
            ViewData["StatusPagoId"] = new SelectList(_context.StatusPagos, "Id", "Descripcion", pago.StatusPagoId);
            ViewData["TipoPagoId"] = new SelectList(_context.TipoPagos, "Id", "Descripcion", pago.TipoPagoId);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Monto,NumPago,PerfilId,AutoId,StatusPagoId,CostoAdicionalId,TipoPagoId")] Pago pago)
        {
            if (id != pago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoExists(pago.Id))
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
            ViewData["AutoId"] = new SelectList(_context.Autos, "Id", "Color", pago.AutoId);
            ViewData["CostoAdicionalId"] = new SelectList(_context.CostoAdicionals, "Id", "MontoAdicional", pago.CostoAdicionalId);
            ViewData["PerfilId"] = new SelectList(_context.Perfils, "Id", "Descripcion", pago.PerfilId);
            ViewData["StatusPagoId"] = new SelectList(_context.StatusPagos, "Id", "Descripcion", pago.StatusPagoId);
            ViewData["TipoPagoId"] = new SelectList(_context.TipoPagos, "Id", "Descripcion", pago.TipoPagoId);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Auto)
                .Include(p => p.CostoAdicional)
                .Include(p => p.Perfil)
                .Include(p => p.StatusPago)
                .Include(p => p.TipoPago)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pago == null)
            {
                return NotFound();
            }

            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagos == null)
            {
                return Problem("Entity set 'Gen06_23_MCVContext.Pagos'  is null.");
            }
            var pago = await _context.Pagos.FindAsync(id);
            if (pago != null)
            {
                _context.Pagos.Remove(pago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoExists(int id)
        {
          return _context.Pagos.Any(e => e.Id == id);
        }
    }
}

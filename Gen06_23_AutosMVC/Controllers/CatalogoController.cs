using Gen06_23_AutosMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gen06_23_AutosMVC.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly Gen06_23_MCVContext _context;

        public CatalogoController(Gen06_23_MCVContext context)
        {
            _context = context;
        }
        // GET: CatalogoController
        public async Task<ActionResult> Index()
        {
            var gen06_23_MCVContext = _context.Autos.Include(a => a.StatusAuto);
            return View(await gen06_23_MCVContext.ToListAsync());
        }

        // GET: CatalogoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CatalogoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatalogoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CatalogoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CatalogoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CatalogoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

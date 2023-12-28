using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Data;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Controllers
{
    public class KoltukDuzenisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KoltukDuzenisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KoltukDuzenis
        public async Task<IActionResult> Index()
        {
              return _context.koltukDuzenis != null ? 
                          View(await _context.koltukDuzenis.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.koltukDuzenis'  is null.");
        }

        // GET: KoltukDuzenis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.koltukDuzenis == null)
            {
                return NotFound();
            }

            var koltukDuzeni = await _context.koltukDuzenis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koltukDuzeni == null)
            {
                return NotFound();
            }

            return View(koltukDuzeni);
        }

        // GET: KoltukDuzenis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KoltukDuzenis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DuzenAdi,SolSira,SağSira")] KoltukDuzeni koltukDuzeni)
        {
            if (ModelState.IsValid)
            {
                _context.Add(koltukDuzeni);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(koltukDuzeni);
        }

        // GET: KoltukDuzenis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.koltukDuzenis == null)
            {
                return NotFound();
            }

            var koltukDuzeni = await _context.koltukDuzenis.FindAsync(id);
            if (koltukDuzeni == null)
            {
                return NotFound();
            }
            return View(koltukDuzeni);
        }

        // POST: KoltukDuzenis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DuzenAdi,SolSira,SağSira")] KoltukDuzeni koltukDuzeni)
        {
            if (id != koltukDuzeni.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(koltukDuzeni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoltukDuzeniExists(koltukDuzeni.Id))
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
            return View(koltukDuzeni);
        }

        // GET: KoltukDuzenis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.koltukDuzenis == null)
            {
                return NotFound();
            }

            var koltukDuzeni = await _context.koltukDuzenis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koltukDuzeni == null)
            {
                return NotFound();
            }

            return View(koltukDuzeni);
        }

        // POST: KoltukDuzenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.koltukDuzenis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.koltukDuzenis'  is null.");
            }
            var koltukDuzeni = await _context.koltukDuzenis.FindAsync(id);
            if (koltukDuzeni != null)
            {
                _context.koltukDuzenis.Remove(koltukDuzeni);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KoltukDuzeniExists(int id)
        {
          return (_context.koltukDuzenis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

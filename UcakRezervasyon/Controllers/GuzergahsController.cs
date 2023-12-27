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
    public class GuzergahsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuzergahsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Guzergahs
        public async Task<IActionResult> Index()
        {
              return _context.guzergahs != null ? 
                          View(await _context.guzergahs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.guzergahs'  is null.");
        }

        // GET: Guzergahs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.guzergahs == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergahs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guzergah == null)
            {
                return NotFound();
            }

            return View(guzergah);
        }

        // GET: Guzergahs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Guzergahs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,kalkis,varis,ucusSuresi")] Guzergah guzergah)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guzergah);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(guzergah);
        }

        // GET: Guzergahs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.guzergahs == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergahs.FindAsync(id);
            if (guzergah == null)
            {
                return NotFound();
            }
            return View(guzergah);
        }

        // POST: Guzergahs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,kalkis,varis,ucusSuresi")] Guzergah guzergah)
        {
            if (id != guzergah.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guzergah);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuzergahExists(guzergah.Id))
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
            return View(guzergah);
        }

        // GET: Guzergahs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.guzergahs == null)
            {
                return NotFound();
            }

            var guzergah = await _context.guzergahs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guzergah == null)
            {
                return NotFound();
            }

            return View(guzergah);
        }

        // POST: Guzergahs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.guzergahs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.guzergahs'  is null.");
            }
            var guzergah = await _context.guzergahs.FindAsync(id);
            if (guzergah != null)
            {
                _context.guzergahs.Remove(guzergah);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuzergahExists(int id)
        {
          return (_context.guzergahs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

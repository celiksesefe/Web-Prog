using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Data;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Controllers
{
    public class KoltukSecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KoltukSecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KoltukSecs
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.koltukSecs.Include(k => k.Ucus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KoltukSecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.koltukSecs == null)
            {
                return NotFound();
            }

            var koltukSec = await _context.koltukSecs
                .Include(k => k.Ucus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koltukSec == null)
            {
                return NotFound();
            }

            return View(koltukSec);
        }

        // GET: KoltukSecs/Create
        public IActionResult Create()
        {
            ViewData["ucusId"] = new SelectList(_context.ucus, "Id", "Id");
            return View();
        }

        // POST: KoltukSecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ucusId,koltukNumarasi")] KoltukSec koltukSec)
        {
            ViewData["ucusId"] = new SelectList(_context.ucus, "Id", "Id", koltukSec.ucusId);

            bool isSeatAlreadyRented = await _context.koltukSecs.AnyAsync(k => k.ucusId == koltukSec.ucusId && k.koltukNumarasi == koltukSec.koltukNumarasi);

            KoltukSec? koltuk = await _context.koltukSecs.FindAsync(koltukSec.ucusId);

            if(isSeatAlreadyRented)
            {
                return View("Basarisiz");
            }
            koltukSec.kiralanmaDurumu = true;    
            
            _context.Add(koltukSec);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }

        // GET: KoltukSecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.koltukSecs == null)
            {
                return NotFound();
            }

            var koltukSec = await _context.koltukSecs.FindAsync(id);
            if (koltukSec == null)
            {
                return NotFound();
            }
            ViewData["ucusId"] = new SelectList(_context.ucus, "Id", "Id", koltukSec.ucusId);
            return View(koltukSec);
        }

        // POST: KoltukSecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ucusId,koltukNumarasi,kiralanmaDurumu")] KoltukSec koltukSec)
        {
            if (id != koltukSec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(koltukSec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoltukSecExists(koltukSec.Id))
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
            ViewData["ucusId"] = new SelectList(_context.ucus, "Id", "Id", koltukSec.ucusId);
            return View(koltukSec);
        }

        // GET: KoltukSecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.koltukSecs == null)
            {
                return NotFound();
            }

            var koltukSec = await _context.koltukSecs
                .Include(k => k.Ucus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (koltukSec == null)
            {
                return NotFound();
            }

            return View(koltukSec);
        }

        // POST: KoltukSecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.koltukSecs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.koltukSecs'  is null.");
            }
            var koltukSec = await _context.koltukSecs.FindAsync(id);
            if (koltukSec != null)
            {
                _context.koltukSecs.Remove(koltukSec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KoltukSecExists(int id)
        {
            return (_context.koltukSecs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

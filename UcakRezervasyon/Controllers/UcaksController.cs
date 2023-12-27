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
    public class UcaksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UcaksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ucaks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ucaks.Include(u => u.KoltukDuzeni).Include(u => u.ucakModeli);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ucaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ucaks == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucaks
                .Include(u => u.KoltukDuzeni)
                .Include(u => u.ucakModeli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // GET: Ucaks/Create
        public IActionResult Create()
        {
            ViewData["KoltukDuzeniId"] = new SelectList(_context.koltukDuzenis, "Id", "DuzenAdi");
            ViewData["UcakModeliId"] = new SelectList(_context.ucakModelis, "Id", "Id");
            return View();
        }

        // POST: Ucaks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UcakModeliId,KoltukDuzeniId")] Ucak ucak)
        {
            KoltukDuzeni koltukDuzeni = await _context.koltukDuzenis.FindAsync(ucak.KoltukDuzeniId);

            ucak.KoltukSayisi = koltukDuzeni.SutunSayisi * koltukDuzeni.SiraSayisi;
            if (ModelState.IsValid)
            {
                _context.Add(ucak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KoltukDuzeniId"] = new SelectList(_context.koltukDuzenis, "Id", "DuzenAdi", ucak.KoltukDuzeniId);
            ViewData["UcakModeliId"] = new SelectList(_context.ucakModelis, "Id", "Id", ucak.UcakModeliId);
            return View(ucak);
        }

        // GET: Ucaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ucaks == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucaks.FindAsync(id);
            if (ucak == null)
            {
                return NotFound();
            }
            ViewData["KoltukDuzeniId"] = new SelectList(_context.koltukDuzenis, "Id", "DuzenAdi", ucak.KoltukDuzeniId);
            ViewData["UcakModeliId"] = new SelectList(_context.ucakModelis, "Id", "Id", ucak.UcakModeliId);
            return View(ucak);
        }

        // POST: Ucaks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UcakModeliId,KoltukDuzeniId,KoltukSayisi")] Ucak ucak)
        {
            if (id != ucak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcakExists(ucak.Id))
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
            ViewData["KoltukDuzeniId"] = new SelectList(_context.koltukDuzenis, "Id", "DuzenAdi", ucak.KoltukDuzeniId);
            ViewData["UcakModeliId"] = new SelectList(_context.ucakModelis, "Id", "Id", ucak.UcakModeliId);
            return View(ucak);
        }

        // GET: Ucaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ucaks == null)
            {
                return NotFound();
            }

            var ucak = await _context.ucaks
                .Include(u => u.KoltukDuzeni)
                .Include(u => u.ucakModeli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucak == null)
            {
                return NotFound();
            }

            return View(ucak);
        }

        // POST: Ucaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ucaks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ucaks'  is null.");
            }
            var ucak = await _context.ucaks.FindAsync(id);
            if (ucak != null)
            {
                _context.ucaks.Remove(ucak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcakExists(int id)
        {
          return (_context.ucaks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

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
    public class UcakModelisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UcakModelisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UcakModelis
        public async Task<IActionResult> Index()
        {
              return _context.ucakModelis != null ? 
                          View(await _context.ucakModelis.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ucakModelis'  is null.");
        }

        // GET: UcakModelis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ucakModelis == null)
            {
                return NotFound();
            }

            var ucakModeli = await _context.ucakModelis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucakModeli == null)
            {
                return NotFound();
            }

            return View(ucakModeli);
        }

        // GET: UcakModelis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UcakModelis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UcakMarkasi,kapasite")] UcakModeli ucakModeli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ucakModeli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ucakModeli);
        }

        // GET: UcakModelis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ucakModelis == null)
            {
                return NotFound();
            }

            var ucakModeli = await _context.ucakModelis.FindAsync(id);
            if (ucakModeli == null)
            {
                return NotFound();
            }
            return View(ucakModeli);
        }

        // POST: UcakModelis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UcakMarkasi,kapasite")] UcakModeli ucakModeli)
        {
            if (id != ucakModeli.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ucakModeli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcakModeliExists(ucakModeli.Id))
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
            return View(ucakModeli);
        }

        // GET: UcakModelis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ucakModelis == null)
            {
                return NotFound();
            }

            var ucakModeli = await _context.ucakModelis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucakModeli == null)
            {
                return NotFound();
            }

            return View(ucakModeli);
        }

        // POST: UcakModelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ucakModelis == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ucakModelis'  is null.");
            }
            var ucakModeli = await _context.ucakModelis.FindAsync(id);
            if (ucakModeli != null)
            {
                _context.ucakModelis.Remove(ucakModeli);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcakModeliExists(int id)
        {
          return (_context.ucakModelis?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

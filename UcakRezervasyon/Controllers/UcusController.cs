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
    [Authorize]

    public class UcusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UcusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ucus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ucus.Include(u => u.guzergah).Include(u => u.ucak);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ucus/Details/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus
                .Include(u => u.guzergah)
                .Include(u => u.ucak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // GET: Ucus/Create
        [Authorize(Roles = "admin")]

        public IActionResult Create()
        {
            ViewData["guzergahId"] = new SelectList(_context.guzergahs, "Id", "Name");
            ViewData["ucakId"] = new SelectList(_context.ucaks, "Id", "Id");
            return View();
        }

        // POST: Ucus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Create([Bind("Id,guzergahId,ucakId,ucusZamani")] Ucus ucus)
        {
            ViewData["guzergahId"] = new SelectList(_context.guzergahs, "Id", "Name", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucaks, "Id", "Id", ucus.ucakId);
            _context.Add(ucus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
          
        }

        // GET: Ucus/Edit/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus.FindAsync(id);
            if (ucus == null)
            {
                return NotFound();
            }
            ViewData["guzergahId"] = new SelectList(_context.guzergahs, "Id", "Name", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucaks, "Id", "Id", ucus.ucakId);
            return View(ucus);
        }

        // POST: Ucus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Edit(int id, [Bind("Id,guzergahId,ucakId,ucusZamani")] Ucus ucus)
        {
            if (id != ucus.Id)
            {
                return NotFound();
            }

            ViewData["guzergahId"] = new SelectList(_context.guzergahs, "Id", "Name", ucus.guzergahId);
            ViewData["ucakId"] = new SelectList(_context.ucaks, "Id", "Id", ucus.ucakId);
            try
                {
                    _context.Update(ucus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcusExists(ucus.Id))
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

        // GET: Ucus/Delete/5
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ucus == null)
            {
                return NotFound();
            }

            var ucus = await _context.ucus
                .Include(u => u.guzergah)
                .Include(u => u.ucak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ucus == null)
            {
                return NotFound();
            }

            return View(ucus);
        }

        // POST: Ucus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ucus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ucus'  is null.");
            }
            var ucus = await _context.ucus.FindAsync(id);
            if (ucus != null)
            {
                _context.ucus.Remove(ucus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UcusExists(int id)
        {
          return (_context.ucus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

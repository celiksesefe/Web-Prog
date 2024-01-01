using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Data;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuzergahsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GuzergahsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Guzergahs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guzergah>>> Getguzergahs()
        {
          if (_context.guzergahs == null)
          {
              return NotFound();
          }
            return await _context.guzergahs.Where(x=>x.mesafeKm>500).ToListAsync();
        }

       

    }
}

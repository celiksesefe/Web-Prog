using Microsoft.EntityFrameworkCore;
using WEBAPI.Models;

namespace UcakRezervasyon.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guzergah> guzergahs { get; set; }
       



    }
}
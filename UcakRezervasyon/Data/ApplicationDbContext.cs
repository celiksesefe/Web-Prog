using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Guzergah> guzergahs { get; set; }
        public DbSet<KoltukDuzeni> koltukDuzenis { get; set; }
        public DbSet<UcakModeli> ucakModelis { get; set; }
        public DbSet<Ucak> ucaks { get; set; }
        public DbSet<Ucus> ucus { get; set; }
        public DbSet<KoltukSec> koltukSecs { get; set; }



    }
}
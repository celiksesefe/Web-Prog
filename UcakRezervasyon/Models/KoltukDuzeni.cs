using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class KoltukDuzeni
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DuzenAdi { get; set; }
        public int SolSira { get; set; } // sol sıra
        public int SağSira { get; set; } //sağ sıra

        
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class KoltukSec
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Ucus")]
        [Display(Name ="Uçuş Numarası")]
        public int ucusId { get; set; }
        public Ucus Ucus { get; set; }
        [MaxLength(11, ErrorMessage = "Türkiye Cumhuriyeti Kimlik Numarası 11 Hane Olmalıdır")]
        [MinLength(11, ErrorMessage = "Türkiye Cumhuriyeti Kimlik Numarası 11 Hane Olmalıdır")]
        public string tcNo { get; set; }
        [Display(Name ="Koltuk Numarası")]
        public int koltukNumarasi { get; set; }

        [Display(Name = "Koltuk Doluluğu")]

        public bool kiralanmaDurumu { get; set; }

      

    
        
    
    }
}

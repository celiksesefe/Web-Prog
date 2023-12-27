using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class KoltukSec
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Ucus")]
        public int ucusId { get; set; }
        public Ucus Ucus { get; set; }


        public int koltukNumarasi { get; set; }
        public bool kiralanmaDurumu { get; set; }


    
        
    
    }
}

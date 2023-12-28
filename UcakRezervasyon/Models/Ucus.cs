using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class Ucus
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Guzergah")]
        public int guzergahId { get; set; }
        public Guzergah guzergah { get; set; }

        [ForeignKey("Ucak")]
        public int ucakId { get; set; }
        public Ucak ucak { get; set; }

        public DateTime ucusZamani { get; set; }    


       

    }
}

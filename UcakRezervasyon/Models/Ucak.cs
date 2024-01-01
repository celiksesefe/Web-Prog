using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UcakRezervasyon.Models
{
    public class Ucak
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UcakModeli")]
        public int UcakModeliId { get; set; } //ucakmodelinden referans
        public UcakModeli ucakModeli { get; set; }

        [ForeignKey("KoltukDuzeni")]
        public int KoltukDuzeniId { get; set; }
        public KoltukDuzeni KoltukDuzeni { get; set; }

        
        public int? KoltukSayisi { get; set; } //controllerda hesaplanıyor

     


         

    }
}

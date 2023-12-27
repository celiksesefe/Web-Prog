using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class Guzergah
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string kalkis { get; set; }

        [Required]
        public string varis { get; set; }

        [Required]
        public float ucusSuresi { get; set; }



    }
}

using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class Guzergah
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }    

        [Required]
        [Display(Name = "Kalkış Noktası")]
        public string kalkis { get; set; }

        [Required]
        [Display(Name = "Varış Noktası")]

        public string varis { get; set; }

        [Required]
        [Display(Name = "Uçuş Mesafesi(km)")]

        public int mesafeKm { get; set; }


        [Required]
        [Display(Name="Uçuş Süresi")]
        public float ucusSuresi { get; set; }



    }
}

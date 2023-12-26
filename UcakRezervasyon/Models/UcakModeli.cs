using System.ComponentModel.DataAnnotations;

namespace UcakRezervasyon.Models
{
    public class UcakModeli
    {
        [Key]
        public int Id { get; set; }

        public string UcakMarkasi { get; set; }

        public int kapasite { get; set; }   


    }
}

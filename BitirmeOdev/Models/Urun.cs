using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace BitirmeOdev.Models
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(40)]
        public string Ad { get; set; }
        [MaxLength(128)]
        public string Aciklama { get; set; }
        [Required, MaxLength(40)]
        public string Marka { get; set; }
        [Required, MaxLength(255), DataType(DataType.ImageUrl)]
        public string Gorsel { get; set; }
    }
}

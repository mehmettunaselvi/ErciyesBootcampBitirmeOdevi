using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeOdev.Models
{
    public class ListUrun
    {
        // TODO: Durum için gerekli düzenlemeler sonra kararlaştırılacak

        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Liste))]
        public int ListeId { get; set; }
        [ForeignKey(nameof(Urun))]
        public int UrunId { get; set; }
        [Required]
        public int Miktar { get; set; }
        //public int Durum { get; set; }

        public virtual Liste Liste { get; set; }
        public virtual Urun Urun { get; set; }
    }
}

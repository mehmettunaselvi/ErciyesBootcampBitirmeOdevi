using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeOdev.Models
{
    public class Liste
    {
        public Liste()
        {
            ListUrun = new List<ListUrun>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Kullanici))]
        public int KullaniciId { get; set; }

        [Required, MaxLength(20)]
        public string Ad { get; set; }

        [MaxLength(128)]
        public string Aciklama { get; set; }

        public virtual Kullanici Kullanici { get; set; }
        public virtual List<ListUrun> ListUrun { get; set; }
    }
}

// Liste liste = _context...

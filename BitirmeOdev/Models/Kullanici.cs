using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BitirmeOdev.Models
{
    // TODO: Fluent Api ile modeldeki verilerin iliskelindirilmesi.
    // TODO: (Opsiyonel) Annotationlar Validator ile yapilabilir.
    // TODO: Sifre hashlenerek atilacak.
    // TODO: KayitOl.cshtml icerisinde arayuz duzenlenecek.
    // TODO: (Opsiyonel) Kullanici Giris icin yalnızca email ve sifre degiskeni iceren bir viewmodel olustur.
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]
        public string Ad { get; set; }

        [Required, MaxLength(15)]
        public string Soyad { get; set; }

        [Required, RegularExpression("^\\S+@\\S+\\.\\S+$"), MaxLength(40)]
        public string Email { get; set; }

        [Required, MinLength(8), MaxLength(16)]
        public string Sifre { get; set; }
    }
}

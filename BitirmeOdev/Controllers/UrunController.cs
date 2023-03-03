using BitirmeOdev.Filters;
using BitirmeOdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeOdev.Controllers
{
    [TypeFilter(typeof(AdminAuthFilter))]
    public class UrunController : Controller
    {
        private readonly DatabaseContext _context;

        public UrunController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Liste()
        {
            List<Urun> urunler = _context.Urun.ToList();
            return View(urunler);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Urun urun)
        {
            if(ModelState.IsValid)
            {
                var varmi = _context.Urun.Any(x => x.Ad == urun.Ad);
                if (!varmi)
                {
                    _context.Urun.Add(urun);
                    int durum = _context.SaveChanges();
                    if (durum > 0)
                        return RedirectToAction(nameof(Liste));
                }
            }
            return View(urun);
        }

        public IActionResult Duzenle(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Urun urun = _context.Urun.FirstOrDefault(x => x.Id == id);

            if(urun == null)
                return RedirectToAction(nameof(Liste));

            return View(urun);
        }

        [HttpPost]
        public IActionResult Duzenle(int id, Urun urun)
        {
            if(ModelState.IsValid && urun == null)
            {
                Urun _urun = _context.Urun.FirstOrDefault(x => x.Id == id);
                _urun.Ad = urun.Ad;
                _urun.Aciklama = urun.Aciklama;
                _urun.Marka = urun.Marka;
                _urun.Gorsel = urun.Gorsel;

                int durum = _context.SaveChanges();
                if (durum > 0)
                    return RedirectToAction(nameof(Liste));
            }
            return View();
        }

        public IActionResult Sil(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Liste));

            Urun urun = _context.Urun.FirstOrDefault(x => x.Id == id);

            if (urun == null)
                return RedirectToAction(nameof(Liste));

            return View(urun);
        }

        [HttpPost]
        public IActionResult Sil(int id, Urun urun)
        {
            Urun _urun = _context.Urun.FirstOrDefault(x => x.Id == id);
            _context.Urun.Remove(_urun);
            _context.SaveChanges();
            return RedirectToAction(nameof(Liste));
        }
    }
}

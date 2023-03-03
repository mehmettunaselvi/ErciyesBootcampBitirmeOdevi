using BitirmeOdev.Models;
using BitirmeOdev.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BitirmeOdev.Filters;
using BitirmeOdev.Extensions;

namespace BitirmeOdev.Controllers
{
    [TypeFilter(typeof(AuthFilter))]
    public class ListeController : Controller
    {
        private readonly DatabaseContext _context;

        public ListeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Kullanici kullanici = HttpContext.Session.GetObject<Kullanici>("kullanici");
            List<Liste> liste = _context.Liste.Where(x => x.KullaniciId == kullanici.Id).ToList();
            return View(liste);
        }

        public IActionResult Detay(int? id) // id == ListeId olacak
        {
            // TODO: View kısmında ürün çıkarma işlemi gerçkeleşirse çıkartılan öğenin satırı silinecek

            if(id == null)
                return RedirectToAction("Index");

            Liste liste = _context.Liste.Include(x => x.ListUrun).ThenInclude(x => x.Urun).FirstOrDefault(x => x.Id == id);
            // liste.ListUrun.Urun.Ad

            if(liste == null)
                return RedirectToAction("Index");

            // TODO: Sonra yapılacak
            return View(liste);
        }

        [HttpPost]
        public IActionResult Detay(int id, Liste liste) // id == ListeId olacak
        {
            Liste _liste = _context.Liste.First(x => x.Id == id);
            _liste.Aciklama = liste.Aciklama;
            _context.SaveChanges();
            return RedirectToAction("Detay", id);
        }

        public IActionResult Olustur()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Olustur(Liste liste)
        {
            if(ModelState.IsValid)
            {
                Kullanici kullanici = HttpContext.Session.GetObject<Kullanici>("kullanici");
                liste.KullaniciId = kullanici.Id;
                _context.Liste.Add(liste);
                int durum = _context.SaveChanges();
                if (durum > 0)
                    return RedirectToAction("Index");
            }
            return View(liste);
        }

        public IActionResult Urunler(int? id) // id == ListeId olacak
        {
            List<Urun> urunler = _context.Urun.ToList();
            ViewBag.listeId = id;
            return View(urunler);
        }

        public IActionResult UrunEkle(int? id, int? urunid) // id == ListeId olacak
        {
            Urun urun = _context.Urun.FirstOrDefault(x => x.Id == urunid);
            ViewData["urun"] = urun;
            ViewBag.listeId = id;
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(int id, int urunid, UrunMiktar urunMiktar) // id == ListeId olacak
        {
            ListUrun listUrun = new ListUrun()
            {
                ListeId = id,
                UrunId = urunMiktar.UrunId,
                Miktar = urunMiktar.Miktar
            };
            _context.ListUrun.Add(listUrun);
            _context.SaveChanges();

            return RedirectToAction("Detay", id);
        }

        [HttpDelete] // AJAX ile erişebilir olacak.
        public IActionResult ListeSil(int id) // id == Liste Id
        {
            Liste liste = _context.Liste.Find(id);
            _context.Liste.Remove(liste);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete] // AJAX ile erişebilir olacak.
        public IActionResult UrunCikar(int id) // id == ListUrun Id
        {
            ListUrun listUrun = _context.ListUrun.Find(id);
            _context.ListUrun.Remove(listUrun);
            _context.SaveChanges();
            return Ok();
        }
    }
}

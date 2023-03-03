using BitirmeOdev.Extensions;
using BitirmeOdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BitirmeOdev.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly DatabaseContext _context;

        public KullaniciController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitOl(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Kullanici.Add(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanici);
        }

        public IActionResult Giris()
        {
            if(HttpContext.Session.Keys.Any())
            {
                var kullanici = HttpContext.Session.GetObject<Kullanici>("kullanici");
                if (!kullanici.Admin)
                    return RedirectToAction("Index", "Liste");
                return RedirectToAction("Liste", "Urun");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(string mail, string sifre)
        {
            if (ModelState.IsValid)
            {
                Kullanici kullanici = _context.Kullanici.FirstOrDefault(x => x.Sifre == sifre && x.Email == mail);
                if (kullanici == null)
                {
                    ModelState.AddModelError(string.Empty, "Girdiğiniz mail adresi ya da şifreniz yanlış.");

                    return NotFound();
                }
                HttpContext.Session.SetObject("kullanici", kullanici);
                if (HttpContext.Session.Keys.Any())
                {
                    if (!kullanici.Admin)
                        return RedirectToAction("Index", "Liste");
                    return RedirectToAction("Liste", "Urun");
                }
            }
            return View();
        }

        public async Task<IActionResult> CikisYap()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

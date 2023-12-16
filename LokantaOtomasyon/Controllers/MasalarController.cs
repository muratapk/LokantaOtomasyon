using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LokantaOtomasyon.Controllers
{
    public class MasalarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MasalarController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tumu = _context.Masalars.ToList();
            return View(tumu);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Masalar gelen)
        {
            if(ModelState.IsValid)
            {
                _context.Masalars.Add(gelen);
                _context.SaveChanges();
                TempData["Success"] = "Kayıt Başarılı Şekilde Ekledi";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int Id)
        {
            if(Id==null)
            {
                TempData["Error"] = "Veri Hatası Oluştu";
                return NotFound();
                
            }
            
            var bul = _context.Masalars.Find(Id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Edit(Masalar gelen)
        {
            if(gelen.Masa_Id==null)
            {
                TempData["Error"] = "Veri Hatası Oluştu";
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Masalars.Update(gelen);
                _context.SaveChanges();
                TempData["Success"] = "Kayıt Başarılı Şekilde Düzelti";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int Id)
        {
            if (Id == null)
            {
                TempData["Error"] = "Veri Hatası Oluştu";
                return NotFound();
            }
            var bul = _context.Masalars.Find(Id);
            return View(bul);
        }
        [HttpPost]
        public IActionResult Delete(Masalar gelen)
        {
            _context.Masalars.Remove(gelen);
            _context.SaveChanges();
            TempData["Success"] = "Kayıt Başarılı Şekilde Silindi";
            return RedirectToAction(nameof(Index));
        }
    }
}

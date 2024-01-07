using DataAccessLayer.Data;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public JsonResult MasaSec(int id,bool durum)
        {
            bool success = false;
            var bul = _context.Masalars.Find(id);
            if(bul != null)
            {
                if(durum==false)
                {
                    bul.Masa_Durum = true;
                    
                }
                else
                {
                    bul.Masa_Durum = false;
                }
                _context.Masalars.Update(bul);
                _context.SaveChanges();
                success = true;
                return new JsonResult(success);

            }
            return new JsonResult(success);

        }
        [HttpGet]
        public async Task<IActionResult> MasaListem()
        {
            var masalar = await _context.Masalars.ToListAsync();
            return View(masalar);
        }

    }
}

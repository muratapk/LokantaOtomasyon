using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LokantaOtomasyon.Controllers
{
    public class SiparislerController : Controller
    {
        private readonly ISiparislerRepository _repository;

        public SiparislerController(ISiparislerRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var rollerim = _repository.GetAll();
            return View(rollerim);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Siparisler gelen)
        {
            _repository.Add(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _repository.GetId(u => u.Siparis_Id == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Siparisler gelen)
        {
            _repository.Update(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.GetId(u => u.Siparis_Id == id);

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Siparisler gelen)
        {
            _repository.Delete(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}


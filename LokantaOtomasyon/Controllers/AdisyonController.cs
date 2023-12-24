using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LokantaOtomasyon.Controllers
{
    public class AdisyonController : Controller
    {
        private readonly IAdisyonRepository _repository;

        public AdisyonController(IAdisyonRepository repository)
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
        public IActionResult Create(Adisyon gelen)
        {
            _repository.Add(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _repository.GetId(u => u.Adisyon_Id == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Adisyon gelen)
        {
            _repository.Update(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.GetId(u => u.Adisyon_Id == id);

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Adisyon gelen)
        {
            _repository.Delete(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}


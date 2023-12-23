﻿using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LokantaOtomasyon.Controllers
{
    public class PersonellerController : Controller
    {
        private readonly IPersonellerRepository _repository;

        public PersonellerController(IPersonellerRepository repository)
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
        public IActionResult Create(Personeller gelen)
        {
            _repository.Add(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _repository.GetId(u => u.Personel_Id == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Personeller gelen)
        {
            _repository.Update(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.GetId(u => u.Personel_Id == id);

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Personeller gelen)
        {
            _repository.Delete(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}

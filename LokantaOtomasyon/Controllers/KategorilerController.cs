﻿using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LokantaOtomasyon.Controllers
{
    public class KategorilerController : Controller
    {
       private readonly IKategoriler _repository;

        public KategorilerController(IKategoriler repository)
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
        public IActionResult Create(Kategoriler gelen)
        {
            _repository.Add(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _repository.GetId(u => u.Kategori_Id == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Kategoriler gelen)
        {
            _repository.Update(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.GetId(u => u.Kategori_Id == id);
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Kategoriler gelen)
        {
            _repository.Delete(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}

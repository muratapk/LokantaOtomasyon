using BusinessLayer.Common;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LokantaOtomasyon.Controllers
{
    public class ServislerController : Controller
    {
        private readonly IServislerRepository _repository;
        private readonly IWebHostEnvironment _webHostEnviroment;
        public ServislerController(IServislerRepository repository,IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnviroment = webHostEnvironment;
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
        public IActionResult Create(Servisler gelen,IFormFile Image)
        {
            if (Image != null)
            {
                string filename = Guid.NewGuid().ToString()+Path.GetExtension(Image.FileName);
                string ImagePath = Path.Combine(_webHostEnviroment.WebRootPath, @"Yemek_Resim");
                using (var fileStream=new FileStream(Path.Combine(ImagePath,filename),FileMode.Create))
                {
                    Image.CopyTo(fileStream);
                    gelen.Servis_Image = filename;
                }
            }
            else
            {
                gelen.Servis_Image = "image-not-found.png";
            }
            _repository.Add(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = _repository.GetId(u => u.Servis_Id == id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Servisler gelen,IFormFile Image)
        {
            _repository.Update(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _repository.GetId(u => u.Servis_Id == id);

            return View();
        }
        [HttpPost]
        public IActionResult Delete(Servisler gelen)
        {
            _repository.Delete(gelen);
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}


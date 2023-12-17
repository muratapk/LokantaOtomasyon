using Microsoft.AspNetCore.Mvc;

namespace LokantaOtomasyon.Controllers
{
    public class KategorilerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

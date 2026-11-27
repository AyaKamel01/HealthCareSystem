using Microsoft.AspNetCore.Mvc;

namespace HealthCareSystem.PL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
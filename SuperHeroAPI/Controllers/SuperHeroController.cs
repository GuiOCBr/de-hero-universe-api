using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    public class SuperHeroController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

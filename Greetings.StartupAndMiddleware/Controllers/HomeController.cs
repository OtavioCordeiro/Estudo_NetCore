using Microsoft.AspNetCore.Mvc;

namespace Greetings.StartupAndMiddleware.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Home");
        }
    }
}

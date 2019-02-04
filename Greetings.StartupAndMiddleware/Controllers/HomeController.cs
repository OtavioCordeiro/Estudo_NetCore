using Greetings.StartupAndMiddleware.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Greetings.StartupAndMiddleware.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        private IGreeting _greeting;

        public HomeController(IGreeting greeting)
        {
            _greeting = greeting;
        }

        public IActionResult Index()
        {
            GreetingModel model = new GreetingModel()
            {
                CreateDate = DateTime.Now,
                Id = 1,
                Message = _greeting.GetMessageOfDay()
            };

            return View(model);
        }
    }
}

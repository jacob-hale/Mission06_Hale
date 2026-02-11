using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Hale.Models;

namespace Mission06_Hale.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        public IActionResult AddAMovie()
        {
            return View();
        }
    }
}

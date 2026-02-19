using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Hale.Models;

namespace Mission06_Hale.Controllers
{
    public class HomeController : Controller
    {
        private JoelHiltonMovieCollectionContext _context;
        public HomeController(JoelHiltonMovieCollectionContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddAMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAMovie(Movie movie)
        {
           _context.Movies.Add(movie);
           _context.SaveChanges();

            return View("Confirmation", movie);
        }
    }
}

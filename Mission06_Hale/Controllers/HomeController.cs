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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(new Movie());
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

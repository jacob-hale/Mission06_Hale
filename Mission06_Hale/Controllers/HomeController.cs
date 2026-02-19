using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return View("Confirmation", movie);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(movie);
            }
        }

        public IActionResult ViewAll()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .Where(x => x.Title != null)
                .OrderBy(x => x.Title)
                .ToList();

            //ViewBag.Categories = _context.Categories
            //    .OrderBy(x => x.CategoryName)
            //    .ToList();

            return View(movies); 
        }
    }
}

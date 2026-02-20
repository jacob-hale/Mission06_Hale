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
        public IActionResult Index() //Gets home page
        {
            return View();
        }

        public IActionResult GetToKnowJoel() //Gets the page with Joel's info
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddMovie() //Add a new movie form
        {
            ViewBag.Categories = _context.Categories //ViewBag holds all category names since the Movie table only has the CategoryId
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(new Movie()); //puts a new Movie class into the view so it always has a new MovieID attached to the form
        }
        [HttpPost]
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid) // if all the data is valid, it is added to the db
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();

                return View("Confirmation", movie); // goes to Confirmation page and passes the added movie as a model to be used
            }
            else
            {
                ViewBag.Categories = _context.Categories //if not, it goes back to the AddMovie with the same data attached (so form doesn't reset)
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(movie);
            }
        }

        public IActionResult ViewAll() // Table with all the movie data
        {
            var movies = _context.Movies
                .Include(x => x.Category) // Include the related Category data tied to each Movie
                .Where(x => x.Title != null)
                .OrderBy(x => x.Title)
                .ToList();

            
            return View(movies); 
        }

        [HttpGet]
        public IActionResult Edit(int id) // Uses the MovieID from the row and passes that Movie to the same form as AddMovie
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit); 

        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo) // called the edit Post from form and updates the Movie data
        {
            _context.Movies.Update(updatedInfo);
            _context.SaveChanges();


            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public IActionResult Delete(int id) // uses the MovieID to open the Delete view
        {
            var recordToDelete = _context.Movies
                    .Single(x => x.MovieID == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie) // removes the data associated to the passed MovieID
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("ViewAll");
        }
    }
}

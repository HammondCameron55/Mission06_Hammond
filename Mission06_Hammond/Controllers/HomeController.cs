using Microsoft.AspNetCore.Mvc;
using Mission06_Hammond.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission06_Hammond.Controllers
{
    public class HomeController : Controller
    {
        private MovieDatabaseContext _context;

        public HomeController(MovieDatabaseContext temp) //This is a constructor. It is taking in an HomeController type object and setting it as _logger which is open for everyone to use
        {
            _context = temp;
        }

        //This takes the user to the home page
        public IActionResult Index()
        {
            return View();
        }

        //This method will be called when the user clicks on the JoelInfo link. 
        public IActionResult JoelInfo()
        {
            return View();
        }
        

        //This is the method that will be called when the user clicks the "MovieForm"
        [HttpGet]
        public IActionResult MovieForm() 
        {
            ViewBag.Major = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", new MovieSubmit());
        }

        
        //This is the method that will be called when the user Submits a new movie form
        [HttpPost]
        public IActionResult MovieForm(MovieSubmit response)
        {
            if (ModelState.IsValid)
            {
                _context.movieSubmits.Add(response); //Add record to the database
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View("MovieForm", response);
            }
            
        }

        //This is the method that will be called when the user clicks the "MovieTable" 
        [HttpGet]
        public IActionResult MovieTable()
        {
            var movieList = _context.movieSubmits;
               //Add an orderby if you want to sort the list

            return View(movieList);
        }


        public IActionResult EditMovie(int id)
        {
            var movie = _context.movieSubmits.Find(id);

            return View("MovieForm" ,movie);
        }

    }
}
        
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Mission06_Hammond.Models;
using System;
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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", new Movie());
        }

        
        //This is the method that will be called when the user Submits a new movie form
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Add record to the database
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
            var movieList = _context.Movies
                .Include(m => m.Category) //Include Category data
                .ToList();
               //Add an orderby if you want to sort the list

            return View(movieList);
        }


        public IActionResult Edit(int id)
        {
            Movie movieToEdit = _context.Movies.Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("MovieForm", movieToEdit);
        }

        //This is the method taht will save the changes made with the Edit
        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Update(updatedMovie);
                _context.SaveChanges();
                return RedirectToAction("MovieTable");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();
                return View("MovieForm", updatedMovie);
            }
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Movie movieToDelete = _context.Movies.Single(x => x.MovieId == id);
            if (movieToDelete == null)
            {
                return NotFound(); // Or some other error handling
            }
            return View("Delete", movieToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            var movieToDelete = _context.Movies.Find(movie.MovieId);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("MovieTable");
        }

    }
}

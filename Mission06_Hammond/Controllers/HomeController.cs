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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JoelInfo()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm() 
        {
            return View();
        }

        

        [HttpPost]
        public IActionResult MovieForm(MovieSubmit response)
        {
            _context.movieSubmits.Add(response); //Add record to the database
            _context.SaveChanges();



            return View("Confirmation", response);
        }

    }
}
        
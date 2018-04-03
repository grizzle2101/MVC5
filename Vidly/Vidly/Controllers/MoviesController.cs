using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        //Task 3 - Use ViewModel Data in Controller
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", id = 1 };
            var customers = new List<Customer>
            {
                new Customer{Id=1, Name="Bob"},
                new Customer{Id=2, Name="Burger"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
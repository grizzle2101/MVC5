using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // Task 2 - Create Controller & Pass Data from Model to View
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", id = 1};

            //Pass the movie Object to View.
            return View(movie);
        }
    }
}
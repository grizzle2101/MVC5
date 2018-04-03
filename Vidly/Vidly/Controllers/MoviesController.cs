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

        //Method 1 - Passing Data as Parameter
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", id = 1 };
            return View(movie);
        }


        //Method 2 - Passing Data via Data Dictionary.
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!", id = 1 };

        //    ViewData["Movie"] = movie;

        //    return View(movie);
        //}

        //Method 3 - ViewBag
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!", id = 1 };

        //    ViewBag.Movie = movie;

        //    return View(movie);
        //}



        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
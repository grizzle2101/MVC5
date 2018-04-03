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

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", id = 1 };
            return View(movie);
        }

        //Task 2 - Apply Route Attribute
        //Using Attribute Routes also allows us to Chain Constaints.
        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
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
            var movie = new Movie() { Name = "Shrek!", id = 1};
            return View(movie);
        }

        //Task 2 - Create Action to Respond to Custom Route.
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
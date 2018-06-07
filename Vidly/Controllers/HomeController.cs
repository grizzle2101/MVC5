using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{
    //Task 2 - Apply Authoize @ Controller Level.
    //[Authorize]

    //Task 4 - Allow Annoymous Authentication for Homepage
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Section 8 - Tutorial 6 - Restricting Access
        //Task 1 - Apply Authorize Filter
        //Task 2 - Apply Authoize @ Controller Level.
        //Task 3 - Apply Authoize @ Global Level.
        //Task 4 - Allow Annoymous Authentication for Homepage


        //Task 1 - Apply Authorize Filter
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
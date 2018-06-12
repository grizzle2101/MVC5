using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    //Section 9 - Tutorial 5 - Output Cache
    //Task 1 - Add TimeStamp on HomePage
    //Task 2 - Apply Caching on HomePage
    //Task 3 - Disable all forms of Caching on HomePage

    //Allow Unauthorized Users to Access Homepage.
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //Task 3 - Disable all forms of Caching on HomePage
        [OutputCache(Duration = 0, Location = OutputCacheLocation.Server, NoStore = true)]
        public ActionResult Index() => View();

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Task 2 - Apply Caching on HomePage
        //[OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "*")]
        //public ActionResult Index() => View();

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
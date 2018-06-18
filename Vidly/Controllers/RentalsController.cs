using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{

    //Tutorial 7 - Building Front-End:
    //Task 1 - Create Basic Controller.
    //Task 2 - Create View
    //Task 3 - Add View to Shared Navigation.
    public class RentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
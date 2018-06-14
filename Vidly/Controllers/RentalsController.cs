using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vidly.Controllers
{

    //Task 12 - Create MVC Controller
    public class RentalsController : Controller
    {
        public ActionResult New()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        protected List<Customer> customerList = new List<Customer>()
        {
            new Customer(){Id = 1, Name = "Donald Trump" },
            new Customer(){Id = 2, Name = "Hilary Clinton" },
            new Customer(){Id = 3, Name = "Barrack Obama" },
        };

        //Feature 1 - Display Customer List
        [Route("Customers/")]
        public ActionResult Customers()
        {
            return View(new CustomersViewModel() { customers = customerList });
        }

        //Feature 2 - Details Page per Customer
        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                return View(customerList.Single(c => c.Id == id));
            }
            catch
            {
                return new HttpNotFoundResult();
            }
        }
    }
}
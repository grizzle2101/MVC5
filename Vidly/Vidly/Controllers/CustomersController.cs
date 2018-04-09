using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //Task 1 - Import DBContext
        protected ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Task 2 - Use Context to Retrive CustomerList.
        public ViewResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        //Task 3 - Use Context to Retrive Customer Details.
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}
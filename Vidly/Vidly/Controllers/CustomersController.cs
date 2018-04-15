using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        protected ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //Task 2 - Edit Customer Action
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        //Task 4 - Refactoring Create to Save.
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                //Method 1 - MVC Approved Way:
                //TryUpdateModel(customerInDB, "", new string[] { "Name", "Email"});

                //Method 2 - Manually Changing Properties
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate.Value;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

                //Method 3 - AutoMapper Way
                //Mapper.Map(UpdateCustomerDTO, customerInDB);

            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
    }
}
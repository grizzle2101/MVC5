using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    //Note this class Derices from API Controller, not the normaly MVC Controller.
    public class CustomersController : ApiController
    {
        protected ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //Method 1 - Return Customers
        // GET /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        //Metod 2 - Get Single Customer
        //Get /api/customer/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        //Metod 3 - Create Customer
        //POST /API/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //Metod 4 - Update Customer
        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //For now we Assign Properties manually, could use AutoMapper in future for mapping of properties.
            customerInDB.Name = customer.Name;
            customerInDB.Birthdate = customer.Birthdate;
            customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
        }

        //Metod 5 - Delete Customer
        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}

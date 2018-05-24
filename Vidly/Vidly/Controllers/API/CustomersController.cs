using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        protected ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        //Section 9 - IHttpActionResult
        //Task 1 - Rework CreateCustomer Method.


        public IEnumerable<CustomerDTO> GetCustomers()
        {
            //Using Select Linq Extension Method
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }


        //Task 2 - Refactor GetCustomer
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));

        }


        //Task 1 - Rework CreateCustomer Method.
        //Return IHttpActionResult not DTO.
        //IF ModelState Invalid, Return BadRequest.
        //Return Created & URI for newly created Customer.
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;


            return Created(new Uri(Request.RequestUri + "/" + customer.Id) , customerDto);
        }


        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //Second Argument, is CustomerInDB.
            //We want Entity Framework Change tracker to see the CustomerInDB Values being changed
            //in order for them to be saved.
            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDB);

            
            //We can now remove all the manual Mappings.
            //For now we Assign Properties manually, could use AutoMapper in future for mapping of properties.
            //customerInDB.Name = customerDTO.Name;
            //customerInDB.Birthdate = customerDTO.Birthdate;
            //customerInDB.IsSubscribedToNewsletter = customerDTO.IsSubscribedToNewsletter;
            //customerInDB.MembershipTypeId = customerDTO.MembershipTypeId;

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

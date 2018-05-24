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


        //Section 8 - Camel Casing
        //Task 1 - Change Default Settings for Camel case.


        public IEnumerable<CustomerDTO> GetCustomers()
        {
            //Using Select Linq Extension Method
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }



        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Mapping Customer & DTO, passing value.
            return Mapper.Map<Customer, CustomerDTO>(customer);
        }


        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //Mapping Incoming DTO to Customer for Saving
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            //ID is created OnSave, lets add this value to DTO.
            customerDto.Id = customer.Id;

            //Returning DTO, not Customer Domain Model.
            return customerDto;
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

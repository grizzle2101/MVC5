using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    //Task 1 - Create Basic Controller
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //Task 6 - Flesh out API
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == rentalDto.CustomerID);

            //Load Multiple Movies
            var movies = _context.Movies
                .Where(m => rentalDto.MovieIds.Contains(m.Id));
            
            foreach(var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();

            return Ok();
        }

        public IHttpActionResult GetRentals()
        {
            throw new NotImplementedException();
        }
    }
}

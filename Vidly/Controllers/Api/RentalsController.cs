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

    //Tutorial 4 - Implment Simple API
    //Task 1 - Setup Basic API
    //Exercise - Flesh out API

    //Tutorial 5 - Adding the Details
    //Excercise - Update Domain Model & API to keep track of Rentals.
    //Task 1 - Add NumberAvailable to Movie class.
    //Task 2 - Modify Migration to Initialize NumbersAvailable = NumberInStock
    //Task 3 - Rework API to Manage NumberInStock
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == rentalDto.CustomerID);

            //Load Multiple Movies
            var movies = _context.Movies
                .Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            //Check Availability
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is NOT available.");

                movie.NumberAvailable--;

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

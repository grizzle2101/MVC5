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
        //Task 10 - Edge Cases
        //CustomerId is Invalid, No MovieIds & Invalid MovieIds, Movies not available
        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == rentalDto.CustomerID);

            ////Task 11 - Defensive Prorgamming
            ////Case 1 - Customer doesn't exist.
            //if (customer == null)
            //    return BadRequest("CustomerId is invliad.");

            ////Case 2 - No Movieids Sent.
            //if (rentalDto.MovieIds.Count == 0)
            //    return BadRequest("No MovieIds have been given.");

            //Load Multiple Movies
            var movies = _context.Movies
                .Where(m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            ////Case 3 - One or More Movies don't exist.
            //if (movies.Count != rentalDto.MovieIds.Count)
            //    return BadRequest("One or More MovieIds provided are invalid.");

            foreach (var movie in movies)
            {
                //Case 4 - Movie not Available
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is NOT available.");

                //Task 9 - Reduce Numbers Available
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

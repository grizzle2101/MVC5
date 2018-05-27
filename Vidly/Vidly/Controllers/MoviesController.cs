using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Vidly.Migrations;
using Vidly.Models;
using Vidly.ViewModels;
using AutoMapper;
using Vidly.Dtos;
using System.Web.Http;
using System.Net;

namespace Vidly.Controllers
{
    public class MoviesController : ApiController
    {
        //Section 6 - Final Assignment - Implment CRUD API Operations for Movie controller
        //Task 1 - Use of DTOs
        //Create Movie DTO
        //Task 2 - Setup Mapping for Movies.
        //Copy Customers, but Ignore ID Property mapping.
        //Task 3 - Refactor for Restful Convention
        //Same as before, BadRequest, DataNotFound & Ok etc as per convention.

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Method 1 - Get Movies.
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        //Method 2 - GetMovie w ID.
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));

        }

        //Method 3 - Create Movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();  

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);

            //Get Genre from ID then Bind to Movie Obj
            movie.Genre = _context.Genres.SingleOrDefault(g => g.Id == movie.GenreId);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);

        }

        //Method 4 - Update/Edit Movie
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDB = _context.Movies.SingleOrDefault(m => m.Id == id);

            //Get Genre from ID then Bind to Movie Obj
            movieInDB.Genre = _context.Genres.SingleOrDefault(g => g.Id == movieDTO.GenreId);

            if (movieInDB == null)
                return NotFound();

            Mapper.Map<MovieDTO, Movie>(movieDTO, movieInDB);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + id), movieDTO);

        }

        //Method 5 - Delete Movie
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
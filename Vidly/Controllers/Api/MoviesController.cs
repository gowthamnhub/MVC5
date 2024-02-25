using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.Models.DbContext;
using Vidly.Models.Dtos;

namespace Vidly.Controllers.Api
{
  public class MoviesController : ApiController
  {
    private readonly VidlyDbContext _context;

    public MoviesController()
    {
      _context = new VidlyDbContext();
    }

    public MoviesController(VidlyDbContext context)
    {
      _context = context;//Dependency injection is not working
    }
    public IHttpActionResult Get()
    {
      var movies = _context.Movies.ToList();
      var moviesDto = new List<MovieDto>();
      Mapper.Map<List<Movie>, List<MovieDto>>(movies, moviesDto);
      return Ok(moviesDto);
    }

    public IHttpActionResult GetById(int id)
    {
      var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

      if (movie == null)
        return Content(HttpStatusCode.NotFound, $"NoResourceIdentifierExistsForGivenId: {id}");

      var movieDto = new MovieDto();
      Mapper.Map<Movie, MovieDto>(movie, movieDto);
      return Ok(movieDto);
    }

    public IHttpActionResult Create(MovieDto movieDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var newMovie = Mapper.Map<MovieDto, Movie>(movieDto);
      newMovie.DateAdded = DateTime.Now;
      _context.Movies.Add(newMovie);
      _context.SaveChanges();

      movieDto.Id = newMovie.Id;
      return Created(Request.RequestUri + movieDto.Id.ToString(), movieDto);
    }
    [HttpPut]
    public IHttpActionResult Update(int id, MovieDto movieDto)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      //get existing movie
      var existingMovie = _context.Movies.SingleOrDefault(x => x.Id == id);
      if (existingMovie == null)
      {
        return Content(HttpStatusCode.NotFound, "No resource identified with the given identifier.");
      }
      
      Mapper.Map<MovieDto, Movie>(movieDto, existingMovie);
      _context.SaveChanges();

      //movieDto.Id = id;
      return Ok(movieDto);
    }
    [HttpDelete]
    public IHttpActionResult Delete(int id)
    {
      //get existing movie
      var movieToBeDeleted = _context.Movies.SingleOrDefault(x => x.Id == id);
      if (movieToBeDeleted == null)
      {
        return Content(HttpStatusCode.NotFound, "No resource identified with the given identifier.");
      }

      _context.Movies.Remove(movieToBeDeleted);
      _context.SaveChanges();

      //movieDto.Id = id;
      return Ok(Mapper.Map<Movie, MovieDto>(movieToBeDeleted, new MovieDto()));
    }
  }
}

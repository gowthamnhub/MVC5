using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.DbContext;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //List<Movie> movies = new List<Movie>()
        //{
        //    new Movie { Id = 1, Name = "Shrek!" },
        //    new Movie { Id = 2, Name = "Dark" },
        //    new Movie { Id = 3, Name = "Just love!" }
        //};
        //List<Customer> customers = new List<Customer>
        //{
        //    new Customer { Id = 1001, Name = "Gowthaman" },
        //    new Customer { Id = 1002, Name = "Kavin" },
        //    new Customer { Id = 1003, Name = "Sangeetha" }
        //};
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
           
            var movies = _context.Movies.Include(x=> x.Genre).ToList();
            return View(movies);

            // ViewData["movies"] = movies;
            //ViewBag.movies = movies;
            //return Content("Hello World!");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            //https://localhost:44318/?page=1&sortBy=name
        }

        public ActionResult New()
        {
            var listOfGenre = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genres = listOfGenre
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int? Id)
        {
            var movie = _context.Movies.Include(x => x.Genre).FirstOrDefault(x => x.Id == Id);
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(x=> x.Genre).FirstOrDefault(x=> x.Id == id);
            return View(movie);
        }
 
        [Route("movies/released/{year:min(1960):max(2023)}/{month:max(12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year: {year}, month:{month}");
        }

        [Route("movies/customers/{movieId}")]
        public ActionResult MoviesWithRentedCustomers(int movieId)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
            MovieCustomersViewModel viewModel = new MovieCustomersViewModel
            {
                Movie = movie,
                Customers = _context.Customers.ToList()
            };

            return View(viewModel);
            //return PartialView("_NavBar");
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                //edit logic
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Shrek!" },
            new Movie { Id = 2, Name = "Dark" },
            new Movie { Id = 3, Name = "Just love!" }
        };
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1001, Name = "Gowthaman" },
            new Customer { Id = 1002, Name = "Kavin" },
            new Customer { Id = 1003, Name = "Sangeetha" }
        };
        // GET: Movies
        public ActionResult Index()
        {
           

           // ViewData["movies"] = movies;
            //ViewBag.movies = movies;
            return View(movies);
            //return Content("Hello World!");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            //https://localhost:44318/?page=1&sortBy=name
        }

        public ActionResult Edit(int? movieId)
        {
            return Content(String.Format("id = {0}", movieId));

        }
 
        [Route("movies/released/{year:min(1960):max(2023)}/{month:max(12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year: {year}, month:{month}");
        }
        [Route("movies/customers/{movieId}")]

        public ActionResult MoviesWithRentedCustomers(int movieId)
        {
            var movie = movies.FirstOrDefault(x => x.Id == movieId);
            MovieCustomersViewModel viewModel = new MovieCustomersViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return PartialView("_NavBar");
        }
    }
}
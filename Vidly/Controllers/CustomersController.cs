using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.DbContext;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //List<Customer> lstCustomers = new List<Customer>
        //{
        //    new Customer { Id = 1001, Name = "Gowthaman" },
        //    new Customer { Id = 1002, Name = "Kavin" },
        //    new Customer { Id = 1003, Name = "Sangeetha" }
        //};

        private VidlyDbContext _context;
        public CustomersController()
        {
            _context = new VidlyDbContext();//we are not using dependency injection here.
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x=> x.MembershipType) .ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}
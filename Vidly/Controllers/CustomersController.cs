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
            var customers = _context.Customers.Include(x=> x.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View(newCustomerViewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
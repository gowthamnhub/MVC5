using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1001, Name = "Gowthaman" },
            new Customer { Id = 1002, Name = "Kavin" },
            new Customer { Id = 1003, Name = "Sangeetha" }
        };
        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }
    }
}
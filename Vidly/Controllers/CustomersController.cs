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
            var newCustomerViewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", newCustomerViewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel or autoMapper - but these updates entire model, sometimes we may need only specific properties to be updated
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            CustomerFormViewModel viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}
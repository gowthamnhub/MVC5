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
    private VidlyDbContext _context;
    public CustomersController()
    {
      _context = new VidlyDbContext();//we are not using dependency injection here.
    }
    // GET: Customers
    public ActionResult Index()
    {
      var customers = _context.Customers.Include(x => x.MembershipType).ToList();
      return View(customers);
    }

    public ActionResult Details(int id)
    {
      var customer = _context.Customers.Include(x => x.MembershipType).FirstOrDefault(c => c.Id == id);
      return View(customer);
    }

    public ActionResult Create()
    {
      var membershipTypes = _context.MembershipTypes.ToList();
      var newCustomerViewModel = new CustomerFormViewModel()
      {
        Customer = new Customer(),
        MembershipTypes = membershipTypes
      };
      return View("CustomerForm", newCustomerViewModel);
    }

    [HttpPost]//Put does not seem to be supported from view, as formMethod I can set only to FormMethod.POST or FormMethod.GET
    public ActionResult Save(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        var viewModel = new CustomerFormViewModel
        {
          Customer = customer,
          MembershipTypes = _context.MembershipTypes.ToList()
        };

        return View("CustomerForm", viewModel);
      }
      if (customer.Id == 0)
      {
        _context.Customers.Add(customer);
      }
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
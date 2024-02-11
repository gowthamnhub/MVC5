using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.DbContext;

namespace Vidly.Controllers.Api
{
  public class CustomersController : ApiController
  {
    private readonly VidlyDbContext _context;

    public CustomersController()
    {
      _context = new VidlyDbContext();
    }

    public CustomersController(VidlyDbContext context)
    {
      _context = context;
    }
    //api/customers
    public IList<Customer> GetCustomers()
    {
      return _context.Customers.ToList();
    }
    //api/customers/1
    public Customer GetById(int id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
      return customer ?? throw new HttpResponseException(HttpStatusCode.NotFound);
    }

    [HttpPost]
    //api/customers
    public Customer Add(Customer customer)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }
      else
      {
        //we have to add customer to context.customers
        var newCustomer = _context.Customers.Add(customer);
        _context.SaveChanges();
        return newCustomer;
      }
    }

    [HttpPut]
    //api/customers/1 (with request body) 
    public Customer Update(int id, Customer customer)
    {
      var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if (existingCustomer == null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }
      else
      {
        //update each properties for the customer
        //instead of assigning these values individually, we can use tools to auto map these properties like AutoMapper.
        existingCustomer.Name = customer.Name;
        existingCustomer.BirthDate = customer.BirthDate;
        existingCustomer.MembershipTypeId = customer.MembershipTypeId;
        existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

        _context.SaveChanges();
        return existingCustomer;
      }
    }

    [HttpDelete]
    //api/customers/1 
    public Customer Delete(int id)
    {
      var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if (existingCustomer == null)
      {
        throw new HttpResponseException(HttpStatusCode.NotFound);
      }
      else
      {
        //remove customer from the DB
        _context.Customers.Remove(existingCustomer); //this object will be marked as removed in memory
        _context.SaveChanges();
        return existingCustomer;
      }
    }


  }
}

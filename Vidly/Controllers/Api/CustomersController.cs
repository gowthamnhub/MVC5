using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Models;
using Vidly.Models.DbContext;
using Vidly.Models.Dtos;

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
    public IEnumerable<CustomerDto> GetCustomers()
    {
      return _context.Customers.ToList().Select(x => Mapper.Map<Customer, CustomerDto>(x));
    }
    //api/customers/1
    public CustomerDto GetById(int id)
    {
      var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if(customer == null)
          throw new HttpResponseException(HttpStatusCode.NotFound);

      return Mapper.Map<Customer, CustomerDto>(customer);
    }

    [HttpPost]
    //api/customers
    public CustomerDto Add(CustomerDto customerDto)
    {
      if (!ModelState.IsValid)
      {
        throw new HttpResponseException(HttpStatusCode.BadRequest);
      }

      //Map customer Dto to customer properties
      //we have to add customer to context.customers
      //var newCustomer = new Customer
      //{
      //  Name = customerDto.Name,
      //  BirthDate = customerDto.BirthDate,
      //  IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter,
      //  MembershipType = customerDto.MembershipType,
      //  MembershipTypeId = customerDto.MembershipTypeId
      //}; 
      //instead of the above lines, when using AutoMapper
      var newCustomer = Mapper.Map<CustomerDto, Customer>(customerDto);
      _context.Customers.Add(newCustomer);
      _context.SaveChanges();
      
      //Once saved, we return DTO object with Id generated for new customer.\
      customerDto.Id = newCustomer.Id;
      return customerDto;
    }

    [HttpPut]
    //api/customers/1 (with request body) 
    public Customer Update(int id, CustomerDto customer)
    {
      var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);
      if (existingCustomer == null) throw new HttpResponseException(HttpStatusCode.NotFound);
      existingCustomer.Name = customer.Name;
      existingCustomer.BirthDate = customer.BirthDate;
      existingCustomer.MembershipTypeId = customer.MembershipTypeId;
      existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

      _context.SaveChanges();
      return existingCustomer;

      //update each properties for the customer
      //instead of assigning these values individually, we can use tools to auto map these properties like AutoMapper.
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

      //remove customer from the DB
      _context.Customers.Remove(existingCustomer); //this object will be marked as removed in memory
      _context.SaveChanges();
      return existingCustomer;
    }
  }
}

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models.DbContext
{
  public class VidlyDbContext : IdentityDbContext<ApplicationUser>
    {
    public VidlyDbContext()
    {

    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public static VidlyDbContext Create()
    {
      return new VidlyDbContext();
    }
  }
}
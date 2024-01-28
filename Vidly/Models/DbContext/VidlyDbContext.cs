using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models.DbContext
{
	public class VidlyDbContext : System.Data.Entity.DbContext
	{
        public VidlyDbContext()
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
	}
}
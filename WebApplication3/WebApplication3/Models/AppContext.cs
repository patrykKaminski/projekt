using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("TEst")
        {

        }

        public DbSet<TestDBmodel> TestDBmodels { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Owner> Owners { get; set; }
    }
}
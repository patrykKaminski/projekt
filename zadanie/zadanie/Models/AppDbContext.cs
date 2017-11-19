using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace zadanie.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        public DbSet<auto> autoDB { get; set; }
        public DbSet<czlowiek> czlowiekDB { get; set; }
        public DbSet<rower> rowerDB { get; set; }
    }
}
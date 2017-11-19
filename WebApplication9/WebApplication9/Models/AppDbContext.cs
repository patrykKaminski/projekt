using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static System.ActivationContext;

namespace WebApplication9.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ContactForm")
        {

        }

        public DbSet<ContextForm> ContactForms { get; set; }
    }
}
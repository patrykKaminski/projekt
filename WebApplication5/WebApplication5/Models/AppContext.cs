using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("ZakupyDB")
        {

        }

        public DbSet<ZakupModel> zakupDBmodels { get; set; }
    }
}
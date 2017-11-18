using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AppContext : DbContext
    {
        public System.Data.Entity.DbSet<WebApplication7.Models.KontaktModel> KontaktModels { get; set; }
    }
}
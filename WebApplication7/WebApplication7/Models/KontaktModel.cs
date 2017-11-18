using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class KontaktModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Temat { get; set; }
        public string Treść { get; set; }
    }
}
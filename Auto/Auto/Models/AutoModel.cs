using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Auto.Models
{
    public class AutoModel : DbContext
    {
        [Required]
        public string Marka { get; set; }
        public string Model { get; set; }
        public string NrRejestracyjny { get; set; }
    }
}
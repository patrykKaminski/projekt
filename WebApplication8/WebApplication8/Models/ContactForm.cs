using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public string Subject { get; set; }
        public string body { get; set; }
    }
}
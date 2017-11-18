using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class ZakupModel 
    {
        public int Id { get; set; }
        public string Produkt { get; set; }
        public int Cena { get; set; }
        public DateTime CzasDodania { get; set; }
        public DateTime CzasModyfikacji { get; set; }
        
    }   
}
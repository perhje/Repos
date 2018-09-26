using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza.Models
{
    public class Bestilling
    {
        public string PizzaType { get; set; }

        public string PizzaTykkelse { get; set; }

        public int Antall { get; set; }
        
    }
}
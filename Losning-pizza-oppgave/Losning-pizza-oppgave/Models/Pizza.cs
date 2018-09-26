using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Losning_pizza_oppgave.Models
{
    // Kunne med fordel delt denne klassen i to, Pizza og Person
    public class Pizza
    {
        public string pizzaType { get; set; }
        public string tykkelse { get; set; }
        public int antall { get; set; }
        public string navn { get; set; }
        public string adresse { get; set; }
        public string telefonnr { get; set; }
    }
}
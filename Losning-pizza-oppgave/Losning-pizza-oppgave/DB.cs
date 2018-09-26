using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Losning_pizza_oppgave.Models;

namespace Losning_pizza_oppgave
{
    public class DB
    {
        public bool settInnBestillng(Pizza bestiltPizza)
        {
            using (var db = new KundeContext())
            {
                var bestilling = new Bestilling()
                {
                    Antall = bestiltPizza.antall,
                    PizzaType = bestiltPizza.pizzaType,
                    TykkBunn = bestiltPizza.tykkelse
                };

                Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == bestiltPizza.navn);

                if (funnetKunde == null)
                {
                    // opprett kunden
                    var kunde = new Kunde
                    {
                        Navn = bestiltPizza.navn,
                        Adresse = bestiltPizza.adresse,
                        Telefonnr = bestiltPizza.telefonnr,
                    };
                    // legg bestillingen inn i kunden
                    kunde.Bestillinger = new List<Bestilling>();
                    kunde.Bestillinger.Add(bestilling);
                    try
                    {
                        db.Kunder.Add(kunde);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception feil)
                    {

                        return false;
                    }
                }
                else
                {
                    try
                    {
                        funnetKunde.Bestillinger.Add(bestilling);
                        db.SaveChanges();
                        return true;
                    }
                    catch (Exception feil)
                    {
                        return false;
                    }
                }
            }
        }

        public List<Pizza> listAlleBestillnger()
        {
            var db = new KundeContext();
            List<Kunde> alleKunder = db.Kunder.ToList();
            List<Pizza> alleBestillinger = new List<Pizza>();
            foreach (var kunde in alleKunder)
            {
                foreach (var best in kunde.Bestillinger)
                {
                    var enBestilling = new Pizza();
                    enBestilling.navn = kunde.Navn;
                    enBestilling.adresse = kunde.Adresse;
                    enBestilling.telefonnr = kunde.Telefonnr;
                    enBestilling.pizzaType = best.PizzaType;
                    enBestilling.antall = best.Antall;
                    enBestilling.tykkelse = best.TykkBunn;
                    alleBestillinger.Add(enBestilling);
                }

            }
            return alleBestillinger;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Losning_pizza_oppgave.Models;

namespace Losning_pizza_oppgave.Controllers
{
    public class PizzaController : Controller
    {
        public ActionResult Index()
        {
            var db = new DB();
            List<Pizza> alleBestillinger = db.listAlleBestillnger();
            return View(alleBestillinger);
        }

        public ActionResult Bestilling()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Bestilling(Pizza innPizza)
        {
            var db = new DB();
            if (db.settInnBestillng(innPizza))
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizza.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bestilling()
        {
            return View();
        }
   
        [HttpPost]
        public ActionResult Bestilling(Models.Bestilling innBestilling)
        {
            using (var db = new Models.DB())
            {
                try
                {
                    db.Bestilling.Add(innBestilling);
                    db.SaveChanges();
                }
                catch(Exception feil)
                {

                }
                return RedirectToAction("Liste");
            }
        }

        public ActionResult Liste()
        {
            using (var db = new Models.DB())
            {
                List<Models.Bestilling> alleBestilling;
                return View(alleBestilling);
            }
        }
    }
}
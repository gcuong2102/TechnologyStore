using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TechnologyStore.Models.EF;

namespace TechnologyStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult TestConnect()
        {
            var db = new DbContextStore();
            if (db.Categories.Count() > 0)
            {
                return RedirectToAction("About");
            }
            else
            {
                return View();
            }
        }
    }
}
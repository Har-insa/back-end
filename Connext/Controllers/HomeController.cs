using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connext.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult WebApi()
        {
            return View();
        }
        public ActionResult creerAgence()
        {
            return View("CreerAgence", new ConnextBusinessLayer.Bdd.AGENCY()); 
        }
    }
}

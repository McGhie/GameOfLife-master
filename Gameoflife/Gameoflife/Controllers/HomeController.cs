using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameoflife.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Templates()
        {
            ViewBag.Message = "Available Templates";

            return View();
        }

        public ActionResult Active()
        {
            ViewBag.Message = "Your Active Games";

            return View();
        }
    }
}
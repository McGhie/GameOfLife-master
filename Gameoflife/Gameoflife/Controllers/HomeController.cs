using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gameoflife.Models;

namespace Gameoflife.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["ActiveGames"]==null)
            {
                Session["ActiveGames"] = new List<UserGame>();
            }
            return View();
        }

        public ActionResult Active()
        {
            ViewBag.Message = "Your Active Games are not here";

            return View();
        }

  
    }
}
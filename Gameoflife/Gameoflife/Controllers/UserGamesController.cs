using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gameoflife.Models;

namespace Gameoflife.Controllers
{
    public class UserGamesController : Controller
    {
        private GameOfLifeDataEntities1 db = new GameOfLifeDataEntities1();

        // GET: UserGames
        public ActionResult Index()
        {
            var userGames = db.UserGames.Include(u => u.User);
            return View(userGames.ToList());
        }


        public ActionResult CreateActiveGameStep1()
        {

            IEnumerable<SelectListItem> items = db.UserTemplates.Select(c => new SelectListItem
            {
                Value = c.UserTemplateID.ToString(),
                Text = c.Name

            });
            ViewBag.userTemplateID = items;
            return View();
        }

       

        public ActionResult CreateActiveGameStep2(int? userTemplateID)
        {

        
            UserTemplate userTemplate = db.UserTemplates.Find(userTemplateID);
            if (userTemplateID == null)
            {
                return RedirectToAction("CreateActiveGameStep1");
            }
            else
            {
                return View(userTemplate);
            }
        }

        public ActionResult AddGames(int? userTemplateID)
        {

            var activeGames = (List<UserGame>)Session["ActiveGames"];

            UserTemplate userTemplate = db.UserTemplates.Find(userTemplateID);
            UserGame newGame = new UserGame();
  
            newGame.Name = userTemplate.Name;
            newGame.Height = userTemplate.Height;
            newGame.Width = userTemplate.Width;
            newGame.Cells = userTemplate.Cells;
            activeGames.Add(newGame);
            Session["ActiveGames"] = activeGames;
            
            return Redirect("MyActiveGames");
        }


        public ActionResult DeleteActiveGame  (int gameIndex)
        {
             var activeGames = (List<UserGame>)Session["ActiveGames"];
             activeGames.RemoveAt(gameIndex);
             Session["ActiveGames"] = activeGames;
            return Redirect("MyActiveGames");
        }

        public ActionResult SaveActiveGame(int gameIndex)
        {

            var activeGames = (List<UserGame>)Session["ActiveGames"];
            UserGame game2Save = activeGames.ElementAt(gameIndex);
            User sessionUser =(User) Session["User"];
           
            User user=db.Users.FirstOrDefault(u => u.Email == sessionUser.Email);
            game2Save.UserID =(int) user.UserID;
            string name = game2Save.Name;
            var height = game2Save.Height;
            db.UserGames.Add(game2Save);
            db.SaveChanges();
            activeGames.RemoveAt(gameIndex);
            Session["ActiveGames"] = activeGames;
            return Redirect("MySavedGames");
        }

        public ActionResult PlaySavedGame(int gameIndex)
        {

            var activeGames = (List<UserGame>)Session["ActiveGames"];

           
            UserGame userGame= db.UserGames.Find(gameIndex);

            UserGame newGame = new UserGame();

            newGame.Name = userGame.Name;
            newGame.Height = userGame.Height;
            newGame.Width = userGame.Width;
            newGame.Cells = userGame.Cells;
            activeGames.Add(newGame);
            Session["ActiveGames"] = activeGames;

            db.UserGames.Remove(userGame);
            db.SaveChanges();

            return Redirect("MyActiveGames");
        }



        public ActionResult DeleteSavedGame(int gameIndex)
        {
            UserGame userGame = db.UserGames.Find(gameIndex);
            db.UserGames.Remove(userGame);
            db.SaveChanges();
            return Redirect("MySavedGames");
        }

        

        // GET: UserGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGame userGame = db.UserGames.Find(id);
            if (userGame == null)
            {
                return HttpNotFound();
            }
            return View(userGame);
        }

        public ActionResult MyActiveGames()
        {
            var activeGames = (List<UserGame>) Session["ActiveGames"];
            return View(activeGames);
        }


        public ActionResult MySavedGames()
        {
            User user = (User)Session["User"];

            if (user == null)
            {
                var userGames = db.UserGames.Include(u => u.User);
                return View(userGames.ToList());
            }
            else
            {
                user = db.Users.Find(user.UserID);

                return View(user.UserGames.ToList());
            }
        }

        // GET: UserGames/Create
        public ActionResult Create()
        {
            //ViewBag.UserTemplates = new SelectList(db.UserTemplates.Select((x=> new { key = x.UserTemplateID, Value = x.Name})));
            var template = new List<SelectListItem>();
            foreach (var x in db.UserTemplates.ToList())
            {
                template.Add(new SelectListItem
                {
                    Text = x.Name,
                    Value = x.UserTemplateID.ToString()
                    
                });
            }

            ViewBag.Templates = template;

            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email");
            return View();
        }

        // POST: UserGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserGameID,UserID,Name,Height,Width,Cells")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                db.UserGames.Add(userGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userGame.UserID);
            return View(userGame);
        }

        // GET: UserGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGame userGame = db.UserGames.Find(id);
            if (userGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userGame.UserID);
            return View(userGame);
        }

        // POST: UserGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserGameID,UserID,Name,Height,Width,Cells")] UserGame userGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userGame.UserID);
            return View(userGame);
        }

        // GET: UserGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGame userGame = db.UserGames.Find(id);
            if (userGame == null)
            {
                return HttpNotFound();
            }
            return View(userGame);
        }

        // POST: UserGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserGame userGame = db.UserGames.Find(id);
            db.UserGames.Remove(userGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

  
    }
}

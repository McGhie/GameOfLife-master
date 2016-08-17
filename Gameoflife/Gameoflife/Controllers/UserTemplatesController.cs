using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gameoflife.Models;
using Microsoft.Ajax.Utilities;

namespace Gameoflife.Controllers
{
    public class UserTemplatesController : Controller
    {
        private GameOfLifeDataEntities1 db = new GameOfLifeDataEntities1();


        // GET: UserTemplates
        public ActionResult All(string templateTitle, int pageNumber = 1 )
        {

            const int PageSize = 5;

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = PageSize;
            ViewBag.TotalCells = db.UserTemplates.Count();

            if (!string.IsNullOrEmpty(templateTitle))
            {


                /* Select only those templates which contain the name
                 * being searched for.
                templates = templates.Where(t => t.Name.Contains(templateTitle));*/
                return View(db.UserTemplates.OrderBy(u => u.UserID).Where(t => t.Name.Contains(templateTitle)).Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList());
            }

           return
                    View(db.UserTemplates.OrderBy(u => u.UserID).Skip((pageNumber - 1)*PageSize).Take(PageSize).ToList());
          


        }




        // GET: UserTemplates
        public ActionResult Index()
        {

           User user = (User) Session["User"];

            if (user == null)
            {
                var userTemplates = db.UserTemplates.Include(u => u.User);
                return View(userTemplates.ToList());
            }
            else
            {
                user = db.Users.Find(user.UserID);
         
                return View(user.UserTemplates.ToList());
            }
        }


        // GET: UserTemplates/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: UserTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
     
        public ActionResult Create( UserTemplate userTemplate)
        {
            if (ModelState.IsValid)
            {
                User user = (User) Session["User"];
                userTemplate.UserID = user.UserID;

                db.UserTemplates.Add(userTemplate);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View();
        }

       


        // GET: UserTemplates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTemplate userTemplate = db.UserTemplates.Find(id);
            if (userTemplate == null)
            {
                return HttpNotFound();
            }
            return View(userTemplate);
        }

        // POST: UserTemplates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserTemplate userTemplate = db.UserTemplates.Find(id);
            db.UserTemplates.Remove(userTemplate);
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

      /*  public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            var cells=this.
           /* for (int h = 0; h <= Height - 1; h++)
            {

                for (int w = 0; w <= Width - 1; w++)
                {
                    if (this.Cells[h][w] == Cell.Alive)
                    {
                        output.Append(aliveCellChar); 
                    }
                    else
                    {
                        output.Append(" ");
                    }

                }
                output.AppendLine();
            }


            return output.ToString();
        }*/
    }
}

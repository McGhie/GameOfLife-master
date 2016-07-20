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
    public class UserTemplatesController : Controller
    {
        private GameOfLifeDataEntities db = new GameOfLifeDataEntities();

        // GET: UserTemplates
        public ActionResult Templates()
        {
            var userTemplates = db.UserTemplates.Include(u => u.User);
            return View(userTemplates.ToList());
        }

        // GET: UserTemplates/Details/5
        public ActionResult Details(int? id)
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

        // GET: UserTemplates/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email");
            return View();
        }

        // POST: UserTemplates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserTemplateID,UserID,Name,Height,Width,Cells")] UserTemplate userTemplate)
        {
            if (ModelState.IsValid)
            {
                db.UserTemplates.Add(userTemplate);
                db.SaveChanges();
                return RedirectToAction("Templates");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userTemplate.UserID);
            return View(userTemplate);
        }

        // GET: UserTemplates/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userTemplate.UserID);
            return View(userTemplate);
        }

        // POST: UserTemplates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTemplateID,UserID,Name,Height,Width,Cells")] UserTemplate userTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Templates");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Email", userTemplate.UserID);
            return View(userTemplate);
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
            return RedirectToAction("Templates");
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

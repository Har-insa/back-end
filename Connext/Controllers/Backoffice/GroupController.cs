using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConnextBusinessLayer.Bdd;

namespace Connext.Controllers
{
    public class GroupController : Controller
    {
        private connext_dbEntities db = new connext_dbEntities();

        // GET: Group
        public ActionResult Index()
        {
            return View(db.GROUPs.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GROUP gROUP = db.GROUPs.Find(id);
            if (gROUP == null)
            {
                return HttpNotFound();
            }
            return View(gROUP);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_GROUP,LABEL")] GROUP gROUP)
        {
            if (ModelState.IsValid)
            {
                db.GROUPs.Add(gROUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gROUP);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GROUP gROUP = db.GROUPs.Find(id);
            if (gROUP == null)
            {
                return HttpNotFound();
            }
            return View(gROUP);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_GROUP,LABEL")] GROUP gROUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gROUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gROUP);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GROUP gROUP = db.GROUPs.Find(id);
            if (gROUP == null)
            {
                return HttpNotFound();
            }
            return View(gROUP);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GROUP gROUP = db.GROUPs.Find(id);
            db.GROUPs.Remove(gROUP);
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

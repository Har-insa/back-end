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
    public class ActionController : Controller
    {
        private connext_dbEntities db = new connext_dbEntities();

        // GET: Action
        public ActionResult Index()
        {
            return View(db.ACTIONs.ToList());
        }

        // GET: Action/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTION aCTION = db.ACTIONs.Find(id);
            if (aCTION == null)
            {
                return HttpNotFound();
            }
            return View(aCTION);
        }

        // GET: Action/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Action/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ACTION,LIBELLE")] ACTION aCTION)
        {
            if (ModelState.IsValid)
            {
                db.ACTIONs.Add(aCTION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aCTION);
        }

        // GET: Action/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTION aCTION = db.ACTIONs.Find(id);
            if (aCTION == null)
            {
                return HttpNotFound();
            }
            return View(aCTION);
        }

        // POST: Action/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ACTION,LIBELLE")] ACTION aCTION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCTION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aCTION);
        }

        // GET: Action/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACTION aCTION = db.ACTIONs.Find(id);
            if (aCTION == null)
            {
                return HttpNotFound();
            }
            return View(aCTION);
        }

        // POST: Action/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ACTION aCTION = db.ACTIONs.Find(id);
            db.ACTIONs.Remove(aCTION);
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

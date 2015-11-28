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
    public class PublicationController : Controller
    {
        private connext_dbEntities db = new connext_dbEntities();

        // GET: Publication
        public ActionResult Index()
        {
            var pUBLICATIONs = db.PUBLICATIONs.Include(p => p.CATEGORY).Include(p => p.GROUP).Include(p => p.USER);
            return View(pUBLICATIONs.ToList());
        }

        // GET: Publication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLICATION pUBLICATION = db.PUBLICATIONs.Find(id);
            if (pUBLICATION == null)
            {
                return HttpNotFound();
            }
            return View(pUBLICATION);
        }

        // GET: Publication/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORies, "ID_CATEGORY", "TITLE");
            ViewBag.ID_GROUP = new SelectList(db.GROUPs, "ID_GROUP", "LABEL");
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME");
            return View();
        }

        // POST: Publication/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PUBLICATION,ID_USER,TITLE,DESCRIPTION,ID_CATEGORY,ID_GROUP")] PUBLICATION pUBLICATION)
        {
            if (ModelState.IsValid)
            {
                db.PUBLICATIONs.Add(pUBLICATION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORies, "ID_CATEGORY", "TITLE", pUBLICATION.ID_CATEGORY);
            ViewBag.ID_GROUP = new SelectList(db.GROUPs, "ID_GROUP", "LABEL", pUBLICATION.ID_GROUP);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", pUBLICATION.ID_USER);
            return View(pUBLICATION);
        }

        // GET: Publication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLICATION pUBLICATION = db.PUBLICATIONs.Find(id);
            if (pUBLICATION == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORies, "ID_CATEGORY", "TITLE", pUBLICATION.ID_CATEGORY);
            ViewBag.ID_GROUP = new SelectList(db.GROUPs, "ID_GROUP", "LABEL", pUBLICATION.ID_GROUP);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", pUBLICATION.ID_USER);
            return View(pUBLICATION);
        }

        // POST: Publication/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PUBLICATION,ID_USER,TITLE,DESCRIPTION,ID_CATEGORY,ID_GROUP")] PUBLICATION pUBLICATION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUBLICATION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORies, "ID_CATEGORY", "TITLE", pUBLICATION.ID_CATEGORY);
            ViewBag.ID_GROUP = new SelectList(db.GROUPs, "ID_GROUP", "LABEL", pUBLICATION.ID_GROUP);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", pUBLICATION.ID_USER);
            return View(pUBLICATION);
        }

        // GET: Publication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLICATION pUBLICATION = db.PUBLICATIONs.Find(id);
            if (pUBLICATION == null)
            {
                return HttpNotFound();
            }
            return View(pUBLICATION);
        }

        // POST: Publication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUBLICATION pUBLICATION = db.PUBLICATIONs.Find(id);
            db.PUBLICATIONs.Remove(pUBLICATION);
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

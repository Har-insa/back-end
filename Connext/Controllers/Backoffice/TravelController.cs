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
    public class TravelController : Controller
    {
        private connext_dbEntities db = new connext_dbEntities();

        // GET: Travel
        public ActionResult Index()
        {
            var tRAVELs = db.TRAVELs.Include(t => t.AGENCY).Include(t => t.AGENCY1).Include(t => t.PUBLICATION);
            return View(tRAVELs.ToList());
        }

        // GET: Travel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAVEL tRAVEL = db.TRAVELs.Find(id);
            if (tRAVEL == null)
            {
                return HttpNotFound();
            }
            return View(tRAVEL);
        }

        // GET: Travel/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARRIVALAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME");
            ViewBag.ID_DEPARTUREAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME");
            ViewBag.ID_PUBLICATION = new SelectList(db.PUBLICATIONs, "ID_PUBLICATION", "TITLE");
            return View();
        }

        // POST: Travel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRAVEL,ID_DEPARTUREAGENCY,ID_ARRIVALAGENCY,CAPACITY,DEPARTUREHOUR,ARRIVALHOUR,ID_PUBLICATION")] TRAVEL tRAVEL)
        {
            if (ModelState.IsValid)
            {
                db.TRAVELs.Add(tRAVEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARRIVALAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_ARRIVALAGENCY);
            ViewBag.ID_DEPARTUREAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_DEPARTUREAGENCY);
            ViewBag.ID_PUBLICATION = new SelectList(db.PUBLICATIONs, "ID_PUBLICATION", "TITLE", tRAVEL.ID_PUBLICATION);
            return View(tRAVEL);
        }

        // GET: Travel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAVEL tRAVEL = db.TRAVELs.Find(id);
            if (tRAVEL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARRIVALAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_ARRIVALAGENCY);
            ViewBag.ID_DEPARTUREAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_DEPARTUREAGENCY);
            ViewBag.ID_PUBLICATION = new SelectList(db.PUBLICATIONs, "ID_PUBLICATION", "TITLE", tRAVEL.ID_PUBLICATION);
            return View(tRAVEL);
        }

        // POST: Travel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRAVEL,ID_DEPARTUREAGENCY,ID_ARRIVALAGENCY,CAPACITY,DEPARTUREHOUR,ARRIVALHOUR,ID_PUBLICATION")] TRAVEL tRAVEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRAVEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARRIVALAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_ARRIVALAGENCY);
            ViewBag.ID_DEPARTUREAGENCY = new SelectList(db.AGENCies, "ID_AGENCY", "NAME", tRAVEL.ID_DEPARTUREAGENCY);
            ViewBag.ID_PUBLICATION = new SelectList(db.PUBLICATIONs, "ID_PUBLICATION", "TITLE", tRAVEL.ID_PUBLICATION);
            return View(tRAVEL);
        }

        // GET: Travel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRAVEL tRAVEL = db.TRAVELs.Find(id);
            if (tRAVEL == null)
            {
                return HttpNotFound();
            }
            return View(tRAVEL);
        }

        // POST: Travel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRAVEL tRAVEL = db.TRAVELs.Find(id);
            db.TRAVELs.Remove(tRAVEL);
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

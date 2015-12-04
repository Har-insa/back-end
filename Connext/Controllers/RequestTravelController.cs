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
    public class RequestTravelController : Controller
    {
        private connext_dbEntities db = new connext_dbEntities();

        // GET: RequestTravel
        public ActionResult Index()
        {
            var rEQUEST_TRAVEL = db.REQUEST_TRAVEL.Include(r => r.ACTION).Include(r => r.TRAVEL).Include(r => r.USER);
            return View(rEQUEST_TRAVEL.ToList());
        }

        // GET: RequestTravel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST_TRAVEL rEQUEST_TRAVEL = db.REQUEST_TRAVEL.Find(id);
            if (rEQUEST_TRAVEL == null)
            {
                return HttpNotFound();
            }
            return View(rEQUEST_TRAVEL);
        }

        // GET: RequestTravel/Create
        public ActionResult Create()
        {
            ViewBag.ID_ACTION = new SelectList(db.ACTIONs, "ID_ACTION", "LIBELLE");
            ViewBag.ID_TRAVEL = new SelectList(db.TRAVELs, "ID_TRAVEL", "ID_TRAVEL");
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME");
            return View();
        }

        // POST: RequestTravel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REQUEST_TRAVEL,ID_TRAVEL,ID_USER,ID_ACTION")] REQUEST_TRAVEL rEQUEST_TRAVEL)
        {
            if (ModelState.IsValid)
            {
                db.REQUEST_TRAVEL.Add(rEQUEST_TRAVEL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ACTION = new SelectList(db.ACTIONs, "ID_ACTION", "LIBELLE", rEQUEST_TRAVEL.ID_ACTION);
            ViewBag.ID_TRAVEL = new SelectList(db.TRAVELs, "ID_TRAVEL", "ID_TRAVEL", rEQUEST_TRAVEL.ID_TRAVEL);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", rEQUEST_TRAVEL.ID_USER);
            return View(rEQUEST_TRAVEL);
        }

        // GET: RequestTravel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST_TRAVEL rEQUEST_TRAVEL = db.REQUEST_TRAVEL.Find(id);
            if (rEQUEST_TRAVEL == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ACTION = new SelectList(db.ACTIONs, "ID_ACTION", "LIBELLE", rEQUEST_TRAVEL.ID_ACTION);
            ViewBag.ID_TRAVEL = new SelectList(db.TRAVELs, "ID_TRAVEL", "ID_TRAVEL", rEQUEST_TRAVEL.ID_TRAVEL);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", rEQUEST_TRAVEL.ID_USER);
            return View(rEQUEST_TRAVEL);
        }

        // POST: RequestTravel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REQUEST_TRAVEL,ID_TRAVEL,ID_USER,ID_ACTION")] REQUEST_TRAVEL rEQUEST_TRAVEL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEQUEST_TRAVEL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ACTION = new SelectList(db.ACTIONs, "ID_ACTION", "LIBELLE", rEQUEST_TRAVEL.ID_ACTION);
            ViewBag.ID_TRAVEL = new SelectList(db.TRAVELs, "ID_TRAVEL", "ID_TRAVEL", rEQUEST_TRAVEL.ID_TRAVEL);
            ViewBag.ID_USER = new SelectList(db.USERs, "ID_USER", "FIRST_NAME", rEQUEST_TRAVEL.ID_USER);
            return View(rEQUEST_TRAVEL);
        }

        // GET: RequestTravel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REQUEST_TRAVEL rEQUEST_TRAVEL = db.REQUEST_TRAVEL.Find(id);
            if (rEQUEST_TRAVEL == null)
            {
                return HttpNotFound();
            }
            return View(rEQUEST_TRAVEL);
        }

        // POST: RequestTravel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REQUEST_TRAVEL rEQUEST_TRAVEL = db.REQUEST_TRAVEL.Find(id);
            db.REQUEST_TRAVEL.Remove(rEQUEST_TRAVEL);
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

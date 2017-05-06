using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Core.DataAccess;

namespace FarmersWareHouse.Controllers
{
    public class MarketUnitOfMeaureController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: MarketUnitOfMeaure
        public ActionResult Index()
        {
            return View(db.tbl_LK_MarketUnitOfMeaure.ToList());
        }

        // GET: MarketUnitOfMeaure/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure = db.tbl_LK_MarketUnitOfMeaure.Find(id);
            if (tbl_LK_MarketUnitOfMeaure == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketUnitOfMeaure);
        }

        // GET: MarketUnitOfMeaure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarketUnitOfMeaure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitOfMeasureID,UnitOfMeasureName")] tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_MarketUnitOfMeaure.Add(tbl_LK_MarketUnitOfMeaure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_MarketUnitOfMeaure);
        }

        // GET: MarketUnitOfMeaure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure = db.tbl_LK_MarketUnitOfMeaure.Find(id);
            if (tbl_LK_MarketUnitOfMeaure == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketUnitOfMeaure);
        }

        // POST: MarketUnitOfMeaure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitOfMeasureID,UnitOfMeasureName")] tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_MarketUnitOfMeaure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_MarketUnitOfMeaure);
        }

        // GET: MarketUnitOfMeaure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure = db.tbl_LK_MarketUnitOfMeaure.Find(id);
            if (tbl_LK_MarketUnitOfMeaure == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketUnitOfMeaure);
        }

        // POST: MarketUnitOfMeaure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure = db.tbl_LK_MarketUnitOfMeaure.Find(id);
            db.tbl_LK_MarketUnitOfMeaure.Remove(tbl_LK_MarketUnitOfMeaure);
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

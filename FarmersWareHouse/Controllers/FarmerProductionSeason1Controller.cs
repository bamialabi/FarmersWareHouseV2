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
    public class FarmerProductionSeason1Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmerProductionSeason1
        public ActionResult Index()
        {
            return View(db.tbl_LK_FarmerProductionSeason.ToList());
        }

        // GET: FarmerProductionSeason1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason = db.tbl_LK_FarmerProductionSeason.Find(id);
            if (tbl_LK_FarmerProductionSeason == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerProductionSeason);
        }

        // GET: FarmerProductionSeason1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmerProductionSeason1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductionSeasonID,ProductionSeasonName")] tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmerProductionSeason.Add(tbl_LK_FarmerProductionSeason);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_FarmerProductionSeason);
        }

        // GET: FarmerProductionSeason1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason = db.tbl_LK_FarmerProductionSeason.Find(id);
            if (tbl_LK_FarmerProductionSeason == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerProductionSeason);
        }

        // POST: FarmerProductionSeason1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductionSeasonID,ProductionSeasonName")] tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmerProductionSeason).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_FarmerProductionSeason);
        }

        // GET: FarmerProductionSeason1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason = db.tbl_LK_FarmerProductionSeason.Find(id);
            if (tbl_LK_FarmerProductionSeason == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerProductionSeason);
        }

        // POST: FarmerProductionSeason1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason = db.tbl_LK_FarmerProductionSeason.Find(id);
            db.tbl_LK_FarmerProductionSeason.Remove(tbl_LK_FarmerProductionSeason);
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

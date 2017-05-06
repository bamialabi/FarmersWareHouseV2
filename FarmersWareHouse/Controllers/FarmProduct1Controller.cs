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
    public class FarmProduct1Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmProduct1
        public ActionResult Index()
        {
            var tbl_LK_FarmProduct = db.tbl_LK_FarmProduct.Include(t => t.tbl_LK_FarmActivity).Include(t => t.tbl_LK_MarketUnitOfMeaure);
            return View(tbl_LK_FarmProduct.ToList());
        }

        // GET: FarmProduct1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmProduct tbl_LK_FarmProduct = db.tbl_LK_FarmProduct.Find(id);
            if (tbl_LK_FarmProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmProduct);
        }

        // GET: FarmProduct1/Create
        public ActionResult Create()
        {
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName");
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName");
            return View();
        }

        // POST: FarmProduct1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmProductID,FarmActivityID,ProductName,UnitOfMeasureID")] tbl_LK_FarmProduct tbl_LK_FarmProduct)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmProduct.Add(tbl_LK_FarmProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_FarmProduct.FarmActivityID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_FarmProduct.UnitOfMeasureID);
            return View(tbl_LK_FarmProduct);
        }

        // GET: FarmProduct1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmProduct tbl_LK_FarmProduct = db.tbl_LK_FarmProduct.Find(id);
            if (tbl_LK_FarmProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_FarmProduct.FarmActivityID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_FarmProduct.UnitOfMeasureID);
            return View(tbl_LK_FarmProduct);
        }

        // POST: FarmProduct1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmProductID,FarmActivityID,ProductName,UnitOfMeasureID")] tbl_LK_FarmProduct tbl_LK_FarmProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_FarmProduct.FarmActivityID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_FarmProduct.UnitOfMeasureID);
            return View(tbl_LK_FarmProduct);
        }

        // GET: FarmProduct1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmProduct tbl_LK_FarmProduct = db.tbl_LK_FarmProduct.Find(id);
            if (tbl_LK_FarmProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmProduct);
        }

        // POST: FarmProduct1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmProduct tbl_LK_FarmProduct = db.tbl_LK_FarmProduct.Find(id);
            db.tbl_LK_FarmProduct.Remove(tbl_LK_FarmProduct);
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

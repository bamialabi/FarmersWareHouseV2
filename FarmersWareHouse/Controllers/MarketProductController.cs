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
    public class MarketProductController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: MarketProduct
        public ActionResult Index()
        {
            var tbl_LK_MarketProduct = db.tbl_LK_MarketProduct.Include(t => t.tbl_LK_MarketUnitOfMeaure);
            return View(tbl_LK_MarketProduct.ToList());
        }

        // GET: MarketProduct/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketProduct tbl_LK_MarketProduct = db.tbl_LK_MarketProduct.Find(id);
            if (tbl_LK_MarketProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketProduct);
        }

        // GET: MarketProduct/Create
        public ActionResult Create()
        {
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName");
            return View();
        }

        // POST: MarketProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,UnitOfMeasureID")] tbl_LK_MarketProduct tbl_LK_MarketProduct)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_MarketProduct.Add(tbl_LK_MarketProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_MarketProduct.UnitOfMeasureID);
            return View(tbl_LK_MarketProduct);
        }

        // GET: MarketProduct/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketProduct tbl_LK_MarketProduct = db.tbl_LK_MarketProduct.Find(id);
            if (tbl_LK_MarketProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_MarketProduct.UnitOfMeasureID);
            return View(tbl_LK_MarketProduct);
        }

        // POST: MarketProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,UnitOfMeasureID")] tbl_LK_MarketProduct tbl_LK_MarketProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_MarketProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_LK_MarketProduct.UnitOfMeasureID);
            return View(tbl_LK_MarketProduct);
        }

        // GET: MarketProduct/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketProduct tbl_LK_MarketProduct = db.tbl_LK_MarketProduct.Find(id);
            if (tbl_LK_MarketProduct == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketProduct);
        }

        // POST: MarketProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_MarketProduct tbl_LK_MarketProduct = db.tbl_LK_MarketProduct.Find(id);
            db.tbl_LK_MarketProduct.Remove(tbl_LK_MarketProduct);
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

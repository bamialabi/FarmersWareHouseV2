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
    public class FarmSizeController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmSize
        public ActionResult Index()
        {
            return View(db.tbl_LK_FarmSize.ToList());
        }

        // GET: FarmSize/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmSize tbl_LK_FarmSize = db.tbl_LK_FarmSize.Find(id);
            if (tbl_LK_FarmSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmSize);
        }

        // GET: FarmSize/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmSize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmSizeID,FarmSizeDescription,Category")] tbl_LK_FarmSize tbl_LK_FarmSize)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmSize.Add(tbl_LK_FarmSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_FarmSize);
        }

        // GET: FarmSize/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmSize tbl_LK_FarmSize = db.tbl_LK_FarmSize.Find(id);
            if (tbl_LK_FarmSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmSize);
        }

        // POST: FarmSize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmSizeID,FarmSizeDescription,Category")] tbl_LK_FarmSize tbl_LK_FarmSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_FarmSize);
        }

        // GET: FarmSize/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmSize tbl_LK_FarmSize = db.tbl_LK_FarmSize.Find(id);
            if (tbl_LK_FarmSize == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmSize);
        }

        // POST: FarmSize/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmSize tbl_LK_FarmSize = db.tbl_LK_FarmSize.Find(id);
            db.tbl_LK_FarmSize.Remove(tbl_LK_FarmSize);
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

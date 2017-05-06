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
    public class FarmActivity2Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmActivity2
        public ActionResult Index()
        {
            var tbl_LK_FarmActivity = db.tbl_LK_FarmActivity.Include(t => t.tbl_LK_FarmValueChain);
            return View(tbl_LK_FarmActivity.ToList());
        }

        // GET: FarmActivity2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmActivity tbl_LK_FarmActivity = db.tbl_LK_FarmActivity.Find(id);
            if (tbl_LK_FarmActivity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmActivity);
        }

        // GET: FarmActivity2/Create
        public ActionResult Create()
        {
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName");
            return View();
        }

        // POST: FarmActivity2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmActivityID,ValueChainID,FarmerActivityName")] tbl_LK_FarmActivity tbl_LK_FarmActivity)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmActivity.Add(tbl_LK_FarmActivity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_FarmActivity.ValueChainID);
            return View(tbl_LK_FarmActivity);
        }

        // GET: FarmActivity2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmActivity tbl_LK_FarmActivity = db.tbl_LK_FarmActivity.Find(id);
            if (tbl_LK_FarmActivity == null)
            {
                return HttpNotFound();
            }
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_FarmActivity.ValueChainID);
            return View(tbl_LK_FarmActivity);
        }

        // POST: FarmActivity2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmActivityID,ValueChainID,FarmerActivityName")] tbl_LK_FarmActivity tbl_LK_FarmActivity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmActivity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_FarmActivity.ValueChainID);
            return View(tbl_LK_FarmActivity);
        }

        // GET: FarmActivity2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmActivity tbl_LK_FarmActivity = db.tbl_LK_FarmActivity.Find(id);
            if (tbl_LK_FarmActivity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmActivity);
        }

        // POST: FarmActivity2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmActivity tbl_LK_FarmActivity = db.tbl_LK_FarmActivity.Find(id);
            db.tbl_LK_FarmActivity.Remove(tbl_LK_FarmActivity);
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

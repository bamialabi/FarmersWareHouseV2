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
    public class FarmListController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmList
        public ActionResult Index()
        {
            return View(db.tbl_LK_FarmList.ToList());
        }

        // GET: FarmList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmList tbl_LK_FarmList = db.tbl_LK_FarmList.Find(id);
            if (tbl_LK_FarmList == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmList);
        }

        // GET: FarmList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmListID,FarmName")] tbl_LK_FarmList tbl_LK_FarmList)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmList.Add(tbl_LK_FarmList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_FarmList);
        }

        // GET: FarmList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmList tbl_LK_FarmList = db.tbl_LK_FarmList.Find(id);
            if (tbl_LK_FarmList == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmList);
        }

        // POST: FarmList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmListID,FarmName")] tbl_LK_FarmList tbl_LK_FarmList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_FarmList);
        }

        // GET: FarmList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmList tbl_LK_FarmList = db.tbl_LK_FarmList.Find(id);
            if (tbl_LK_FarmList == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmList);
        }

        // POST: FarmList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmList tbl_LK_FarmList = db.tbl_LK_FarmList.Find(id);
            db.tbl_LK_FarmList.Remove(tbl_LK_FarmList);
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

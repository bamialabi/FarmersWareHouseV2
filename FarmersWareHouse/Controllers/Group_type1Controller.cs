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
    public class Group_type1Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: Group_type1
        public ActionResult Index()
        {
            return View(db.tbl_LK_Group_type.ToList());
        }

        // GET: Group_type1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Group_type tbl_LK_Group_type = db.tbl_LK_Group_type.Find(id);
            if (tbl_LK_Group_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Group_type);
        }

        // GET: Group_type1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group_type1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupTypeID,GroupTypeName")] tbl_LK_Group_type tbl_LK_Group_type)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_Group_type.Add(tbl_LK_Group_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_Group_type);
        }

        // GET: Group_type1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Group_type tbl_LK_Group_type = db.tbl_LK_Group_type.Find(id);
            if (tbl_LK_Group_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Group_type);
        }

        // POST: Group_type1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupTypeID,GroupTypeName")] tbl_LK_Group_type tbl_LK_Group_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_Group_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_Group_type);
        }

        // GET: Group_type1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Group_type tbl_LK_Group_type = db.tbl_LK_Group_type.Find(id);
            if (tbl_LK_Group_type == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Group_type);
        }

        // POST: Group_type1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_Group_type tbl_LK_Group_type = db.tbl_LK_Group_type.Find(id);
            db.tbl_LK_Group_type.Remove(tbl_LK_Group_type);
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

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
    public class StateController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: State
        public ActionResult Index()
        {
            return View(db.tbl_LK_State.ToList());
        }

        // GET: State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_State tbl_LK_State = db.tbl_LK_State.Find(id);
            if (tbl_LK_State == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_State);
        }

        // GET: State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateID,StateName")] tbl_LK_State tbl_LK_State)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_State.Add(tbl_LK_State);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_State);
        }

        // GET: State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_State tbl_LK_State = db.tbl_LK_State.Find(id);
            if (tbl_LK_State == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_State);
        }

        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateID,StateName")] tbl_LK_State tbl_LK_State)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_State).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_State);
        }

        // GET: State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_State tbl_LK_State = db.tbl_LK_State.Find(id);
            if (tbl_LK_State == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_State);
        }

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_State tbl_LK_State = db.tbl_LK_State.Find(id);
            db.tbl_LK_State.Remove(tbl_LK_State);
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

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
    public class LgaController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: Lga
        public ActionResult Index()
        {
            var tbl_LK_Lga = db.tbl_LK_Lga.Include(t => t.tbl_LK_State);
            return View(tbl_LK_Lga.ToList());
        }

        // GET: Lga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Lga tbl_LK_Lga = db.tbl_LK_Lga.Find(id);
            if (tbl_LK_Lga == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Lga);
        }

        // GET: Lga/Create
        public ActionResult Create()
        {
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            return View();
        }

        // POST: Lga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LgaID,LgaName,StateID")] tbl_LK_Lga tbl_LK_Lga)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_Lga.Add(tbl_LK_Lga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Lga.StateID);
            return View(tbl_LK_Lga);
        }

        // GET: Lga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Lga tbl_LK_Lga = db.tbl_LK_Lga.Find(id);
            if (tbl_LK_Lga == null)
            {
                return HttpNotFound();
            }
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Lga.StateID);
            return View(tbl_LK_Lga);
        }

        // POST: Lga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LgaID,LgaName,StateID")] tbl_LK_Lga tbl_LK_Lga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_Lga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Lga.StateID);
            return View(tbl_LK_Lga);
        }

        // GET: Lga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Lga tbl_LK_Lga = db.tbl_LK_Lga.Find(id);
            if (tbl_LK_Lga == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Lga);
        }

        // POST: Lga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_Lga tbl_LK_Lga = db.tbl_LK_Lga.Find(id);
            db.tbl_LK_Lga.Remove(tbl_LK_Lga);
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

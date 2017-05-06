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
    public class SubComponentController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: SubComponent
        public ActionResult Index()
        {
            var tbl_LK_ME_SubComponent = db.tbl_LK_ME_SubComponent.Include(t => t.tbl_LK_ME_Component);
            return View(tbl_LK_ME_SubComponent.ToList());
        }

        // GET: SubComponent/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent = db.tbl_LK_ME_SubComponent.Find(id);
            if (tbl_LK_ME_SubComponent == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_ME_SubComponent);
        }

        // GET: SubComponent/Create
        public ActionResult Create()
        {
            ViewBag.ComponentID = new SelectList(db.tbl_LK_ME_Component, "ComponentID", "ComponentName");
            return View();
        }

        // POST: SubComponent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubComponentID,ComponentID,SubComponentName")] tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_ME_SubComponent.Add(tbl_LK_ME_SubComponent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComponentID = new SelectList(db.tbl_LK_ME_Component, "ComponentID", "ComponentName", tbl_LK_ME_SubComponent.ComponentID);
            return View(tbl_LK_ME_SubComponent);
        }

        // GET: SubComponent/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent = db.tbl_LK_ME_SubComponent.Find(id);
            if (tbl_LK_ME_SubComponent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComponentID = new SelectList(db.tbl_LK_ME_Component, "ComponentID", "ComponentName", tbl_LK_ME_SubComponent.ComponentID);
            return View(tbl_LK_ME_SubComponent);
        }

        // POST: SubComponent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubComponentID,ComponentID,SubComponentName")] tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_ME_SubComponent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComponentID = new SelectList(db.tbl_LK_ME_Component, "ComponentID", "ComponentName", tbl_LK_ME_SubComponent.ComponentID);
            return View(tbl_LK_ME_SubComponent);
        }

        // GET: SubComponent/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent = db.tbl_LK_ME_SubComponent.Find(id);
            if (tbl_LK_ME_SubComponent == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_ME_SubComponent);
        }

        // POST: SubComponent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent = db.tbl_LK_ME_SubComponent.Find(id);
            db.tbl_LK_ME_SubComponent.Remove(tbl_LK_ME_SubComponent);
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

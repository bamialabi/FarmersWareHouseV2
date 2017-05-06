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
    public class FarmerCIGController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmerCIG
        public ActionResult Index()
        {
            var tbl_LK_FarmerCIG = db.tbl_LK_FarmerCIG.Include(t => t.tbl_LK_Group_type).Include(t => t.tbl_LK_State).Include(t => t.tbl_LK_Year);
            return View(tbl_LK_FarmerCIG.ToList());
        }

        // GET: FarmerCIG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerCIG tbl_LK_FarmerCIG = db.tbl_LK_FarmerCIG.Find(id);
            if (tbl_LK_FarmerCIG == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerCIG);
        }

        // GET: FarmerCIG/Create
        public ActionResult Create()
        {
            ViewBag.GroupTypeID = new SelectList(db.tbl_LK_Group_type, "GroupTypeID", "GroupTypeName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "Year");
            return View();
        }

        // POST: FarmerCIG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CIGID,CIGName,StateID,Amount,YearID,dateIssued,GroupTypeID")] tbl_LK_FarmerCIG tbl_LK_FarmerCIG)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmerCIG.Add(tbl_LK_FarmerCIG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupTypeID = new SelectList(db.tbl_LK_Group_type, "GroupTypeID", "GroupTypeName", tbl_LK_FarmerCIG.GroupTypeID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerCIG.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerCIG.YearID);
            return View(tbl_LK_FarmerCIG);
        }

        // GET: FarmerCIG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerCIG tbl_LK_FarmerCIG = db.tbl_LK_FarmerCIG.Find(id);
            if (tbl_LK_FarmerCIG == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupTypeID = new SelectList(db.tbl_LK_Group_type, "GroupTypeID", "GroupTypeName", tbl_LK_FarmerCIG.GroupTypeID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerCIG.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerCIG.YearID);
            return View(tbl_LK_FarmerCIG);
        }

        // POST: FarmerCIG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CIGID,CIGName,StateID,Amount,YearID,dateIssued,GroupTypeID")] tbl_LK_FarmerCIG tbl_LK_FarmerCIG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmerCIG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupTypeID = new SelectList(db.tbl_LK_Group_type, "GroupTypeID", "GroupTypeName", tbl_LK_FarmerCIG.GroupTypeID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerCIG.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerCIG.YearID);
            return View(tbl_LK_FarmerCIG);
        }

        // GET: FarmerCIG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerCIG tbl_LK_FarmerCIG = db.tbl_LK_FarmerCIG.Find(id);
            if (tbl_LK_FarmerCIG == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerCIG);
        }

        // POST: FarmerCIG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmerCIG tbl_LK_FarmerCIG = db.tbl_LK_FarmerCIG.Find(id);
            db.tbl_LK_FarmerCIG.Remove(tbl_LK_FarmerCIG);
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

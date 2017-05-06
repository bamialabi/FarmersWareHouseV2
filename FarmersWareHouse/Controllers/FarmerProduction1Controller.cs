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
    public class FarmerProduction1Controller : Controller
    {
        private CADPEntities db = new CADPEntities();
        
        public JsonResult GetCIGs(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<tbl_LK_FarmerCIG> states = db.tbl_LK_FarmerCIG.Where(stat => stat.StateID == id);
            return Json(states);
        }
        // GET: FarmerProduction1
        public ActionResult Index()
        {
            var tbl_LK_FarmerProduction = db.tbl_LK_FarmerProduction.Include(t => t.tbl_LK_Farmer).Include(t => t.tbl_LK_FarmerCIG).Include(t => t.tbl_LK_FarmerProductionSeason).Include(t => t.tbl_LK_State).Include(t => t.tbl_LK_Year);
            return View(tbl_LK_FarmerProduction.ToList());
        }

        // GET: FarmerProduction1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProduction tbl_LK_FarmerProduction = db.tbl_LK_FarmerProduction.Find(id);
            if (tbl_LK_FarmerProduction == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerProduction);
        }

        // GET: FarmerProduction1/Create
        public ActionResult Create()
        {
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName");
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID");
            return View();
        }

        // POST: FarmerProduction1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmerProductionID,FarmerID,Quantity_10_11,Yield,ProductionSeasonID,YearID,dateCreated,StateID,CIGID,FarmerBenefitID")] tbl_LK_FarmerProduction tbl_LK_FarmerProduction)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmerProduction.Add(tbl_LK_FarmerProduction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerProduction.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerProduction.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerProduction.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerProduction.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerProduction.YearID);
            return View(tbl_LK_FarmerProduction);
        }

        // GET: FarmerProduction1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProduction tbl_LK_FarmerProduction = db.tbl_LK_FarmerProduction.Find(id);
            if (tbl_LK_FarmerProduction == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerProduction.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerProduction.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerProduction.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerProduction.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerProduction.YearID);
            return View(tbl_LK_FarmerProduction);
        }

        // POST: FarmerProduction1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmerProductionID,FarmerID,Quantity_10_11,Yield,ProductionSeasonID,YearID,dateCreated,StateID,CIGID,FarmerBenefitID")] tbl_LK_FarmerProduction tbl_LK_FarmerProduction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmerProduction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerProduction.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerProduction.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerProduction.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerProduction.StateID);
            ViewBag.YearID = new SelectList(db.tbl_LK_Year, "YearID", "YearID", tbl_LK_FarmerProduction.YearID);
            return View(tbl_LK_FarmerProduction);
        }

        // GET: FarmerProduction1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerProduction tbl_LK_FarmerProduction = db.tbl_LK_FarmerProduction.Find(id);
            if (tbl_LK_FarmerProduction == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerProduction);
        }

        // POST: FarmerProduction1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmerProduction tbl_LK_FarmerProduction = db.tbl_LK_FarmerProduction.Find(id);
            db.tbl_LK_FarmerProduction.Remove(tbl_LK_FarmerProduction);
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

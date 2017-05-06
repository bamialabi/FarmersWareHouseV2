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
    public class FarmerBenefit1Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        public JsonResult GetCIGs(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<tbl_LK_FarmerCIG> states = db.tbl_LK_FarmerCIG.Where(stat => stat.StateID == id);
            return Json(states);
        }

        // GET: FarmerBenefit1
        public ActionResult Index()
        {
            var tbl_LK_FarmerBenefit = db.tbl_LK_FarmerBenefit.Include(t => t.tbl_LK_Farmer).Include(t => t.tbl_LK_FarmerCIG).Include(t => t.tbl_LK_FarmerProductionSeason).Include(t => t.tbl_LK_State);
            return View(tbl_LK_FarmerBenefit.ToList());
        }

        // GET: FarmerBenefit1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit = db.tbl_LK_FarmerBenefit.Find(id);
            if (tbl_LK_FarmerBenefit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerBenefit);
        }

        // GET: FarmerBenefit1/Create
        public ActionResult Create()
        {
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName");
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            return View();
        }

        // POST: FarmerBenefit1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmerBenefitID,FarmerID,Amount,ProductionSeasonID,dateIssued,StateID,CIGID,Remark")] tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmerBenefit.Add(tbl_LK_FarmerBenefit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerBenefit.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerBenefit.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerBenefit.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerBenefit.StateID);
            return View(tbl_LK_FarmerBenefit);
        }

        // GET: FarmerBenefit1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit = db.tbl_LK_FarmerBenefit.Find(id);
            if (tbl_LK_FarmerBenefit == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerBenefit.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerBenefit.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerBenefit.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerBenefit.StateID);
            return View(tbl_LK_FarmerBenefit);
        }

        // POST: FarmerBenefit1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmerBenefitID,FarmerID,Amount,ProductionSeasonID,dateIssued,StateID,CIGID,Remark")] tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmerBenefit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmerID = new SelectList(db.tbl_LK_Farmer, "FarmerID", "FarmerName", tbl_LK_FarmerBenefit.FarmerID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_FarmerBenefit.CIGID);
            ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", tbl_LK_FarmerBenefit.ProductionSeasonID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_FarmerBenefit.StateID);
            return View(tbl_LK_FarmerBenefit);
        }

        // GET: FarmerBenefit1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit = db.tbl_LK_FarmerBenefit.Find(id);
            if (tbl_LK_FarmerBenefit == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmerBenefit);
        }

        // POST: FarmerBenefit1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmerBenefit tbl_LK_FarmerBenefit = db.tbl_LK_FarmerBenefit.Find(id);
            db.tbl_LK_FarmerBenefit.Remove(tbl_LK_FarmerBenefit);
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

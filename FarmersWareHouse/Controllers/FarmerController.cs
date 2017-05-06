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
    public class FarmerController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // farmer menu

        public ActionResult FarmerMenu()
        {
            return View();
        }


        public JsonResult GetCIGs(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<tbl_LK_FarmerCIG> states = db.tbl_LK_FarmerCIG.Where(stat => stat.StateID  == id);
            return Json(states);
        }

        // GET: Farmer
        public ActionResult Index()
        {
            var tbl_LK_Farmer = db.tbl_LK_Farmer.ToList(); //.Include(t => t.tbl_LK_FarmActivity).Include(t => t.tbl_LK_FarmerCIG).Include(t => t.tbl_LK_FarmList).Include(t => t.tbl_LK_FarmProduct).Include(t => t.tbl_LK_FarmSize).Include(t => t.tbl_LK_FarmValueChain).Include(t => t.tbl_LK_State);
            return View(tbl_LK_Farmer.ToList());
        }

        // GET: Farmer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Farmer tbl_LK_Farmer = db.tbl_LK_Farmer.Find(id);
            if (tbl_LK_Farmer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Farmer);
        }

        // GET: Farmer/Create
        public ActionResult Create()
        {
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName");
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            ViewBag.FarmListID = new SelectList(db.tbl_LK_FarmList, "FarmListID", "FarmName");
            ViewBag.FarmProductID = new SelectList(db.tbl_LK_FarmProduct, "FarmProductID", "ProductName");
            ViewBag.FarmSizeID = new SelectList(db.tbl_LK_FarmSize, "FarmSizeID", "FarmSizeDescription");
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            return View();
        }

        // POST: Farmer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FarmerID,StateID,CIGID,ValueChainID,FarmActivityID,FarmProductID,FarmerName,MobileNo1,MobileNo2,Sex,BaseLine,FarmSizeID,FarmName,FarmListID")] tbl_LK_Farmer tbl_LK_Farmer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_Farmer.Add(tbl_LK_Farmer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_Farmer.FarmActivityID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_Farmer.CIGID);
            ViewBag.FarmListID = new SelectList(db.tbl_LK_FarmList, "FarmListID", "FarmName", tbl_LK_Farmer.FarmListID);
            ViewBag.FarmProductID = new SelectList(db.tbl_LK_FarmProduct, "FarmProductID", "ProductName", tbl_LK_Farmer.FarmProductID);
            ViewBag.FarmSizeID = new SelectList(db.tbl_LK_FarmSize, "FarmSizeID", "FarmSizeDescription", tbl_LK_Farmer.FarmSizeID);
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_Farmer.ValueChainID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Farmer.StateID);
            return View(tbl_LK_Farmer);
        }

        // GET: Farmer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Farmer tbl_LK_Farmer = db.tbl_LK_Farmer.Find(id);
            if (tbl_LK_Farmer == null)
            {
                return HttpNotFound();
            }
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_Farmer.FarmActivityID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_Farmer.CIGID);
            ViewBag.FarmListID = new SelectList(db.tbl_LK_FarmList, "FarmListID", "FarmName", tbl_LK_Farmer.FarmListID);
            ViewBag.FarmProductID = new SelectList(db.tbl_LK_FarmProduct, "FarmProductID", "ProductName", tbl_LK_Farmer.FarmProductID);
            ViewBag.FarmSizeID = new SelectList(db.tbl_LK_FarmSize, "FarmSizeID", "FarmSizeDescription", tbl_LK_Farmer.FarmSizeID);
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_Farmer.ValueChainID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Farmer.StateID);
            return View(tbl_LK_Farmer);
        }

        // POST: Farmer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FarmerID,StateID,CIGID,ValueChainID,FarmActivityID,FarmProductID,FarmerName,MobileNo1,MobileNo2,Sex,BaseLine,FarmSizeID,FarmName,FarmListID")] tbl_LK_Farmer tbl_LK_Farmer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_Farmer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FarmActivityID = new SelectList(db.tbl_LK_FarmActivity, "FarmActivityID", "FarmerActivityName", tbl_LK_Farmer.FarmActivityID);
            ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName", tbl_LK_Farmer.CIGID);
            ViewBag.FarmListID = new SelectList(db.tbl_LK_FarmList, "FarmListID", "FarmName", tbl_LK_Farmer.FarmListID);
            ViewBag.FarmProductID = new SelectList(db.tbl_LK_FarmProduct, "FarmProductID", "ProductName", tbl_LK_Farmer.FarmProductID);
            ViewBag.FarmSizeID = new SelectList(db.tbl_LK_FarmSize, "FarmSizeID", "FarmSizeDescription", tbl_LK_Farmer.FarmSizeID);
            ViewBag.ValueChainID = new SelectList(db.tbl_LK_FarmValueChain, "ValueChainID", "ValueChainName", tbl_LK_Farmer.ValueChainID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Farmer.StateID);
            return View(tbl_LK_Farmer);
        }

        // GET: Farmer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Farmer tbl_LK_Farmer = db.tbl_LK_Farmer.Find(id);
            if (tbl_LK_Farmer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Farmer);
        }

        // POST: Farmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_Farmer tbl_LK_Farmer = db.tbl_LK_Farmer.Find(id);
            db.tbl_LK_Farmer.Remove(tbl_LK_Farmer);
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

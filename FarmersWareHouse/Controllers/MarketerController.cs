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
    public class MarketerController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: Marketer
        public ActionResult Index()
        {
            var tbl_LK_Marketer = db.tbl_LK_Marketer.Include(t => t.tbl_LK_Lga).Include(t => t.tbl_LK_MarketList).Include(t => t.tbl_LK_State);
            return View(tbl_LK_Marketer.ToList());
        }
        //public JsonResult GetMarketName(string id)
        //{
        //    if (id == null)
        //    {
        //        id = "0";
        //    }


        //    var stateId = Convert.ToInt32(id);


        //    //AllSampleCodeEntities objord = new AllSampleCodeEntities();

        //    var response = (from slist in db.tbl_LK_MarketList
        //                    where (slist.StateID == stateId)
        //                    select new { slist.MarketListID, slist.MarketListName }).ToList();

        //    return Json(new SelectList(response, "MarketListID", "MarketListName"));
        //}

        public JsonResult GetMKT(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<tbl_LK_MarketList> states = db.tbl_LK_MarketList.Where(stat => stat.StateID    == id);
            return Json(states);
        }

        // GET: Marketer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Marketer tbl_LK_Marketer = db.tbl_LK_Marketer.Find(id);
            if (tbl_LK_Marketer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Marketer);
        }

        // GET: Marketer/Create
        public ActionResult Create()
        {
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName");
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            return View();
        }

        // POST: Marketer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketerID,MarketListID,MarketerName,Introducer,StateID,LgaID,MarketAddress,Longitude,Latitude,Location,MobileNo")] tbl_LK_Marketer tbl_LK_Marketer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_Marketer.Add(tbl_LK_Marketer);
                tbl_LK_Marketer.Longitude = 0.4m;
                tbl_LK_Marketer.Latitude= 0.4m;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_Marketer.LgaID);
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_LK_Marketer.MarketListID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Marketer.StateID);
            return View(tbl_LK_Marketer);
        }

        // GET: Marketer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Marketer tbl_LK_Marketer = db.tbl_LK_Marketer.Find(id);
            if (tbl_LK_Marketer == null)
            {
                return HttpNotFound();
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_Marketer.LgaID);
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_LK_Marketer.MarketListID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Marketer.StateID);
            return View(tbl_LK_Marketer);
        }

        // POST: Marketer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketerID,MarketListID,MarketerName,Introducer,StateID,LgaID,MarketAddress,Longitude,Latitude,Location,MobileNo")] tbl_LK_Marketer tbl_LK_Marketer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_Marketer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_Marketer.LgaID);
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_LK_Marketer.MarketListID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_Marketer.StateID);
            return View(tbl_LK_Marketer);
        }

        // GET: Marketer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_Marketer tbl_LK_Marketer = db.tbl_LK_Marketer.Find(id);
            if (tbl_LK_Marketer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_Marketer);
        }

        // POST: Marketer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_Marketer tbl_LK_Marketer = db.tbl_LK_Marketer.Find(id);
            db.tbl_LK_Marketer.Remove(tbl_LK_Marketer);
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

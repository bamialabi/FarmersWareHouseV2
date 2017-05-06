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
    public class MarketListController : Controller
    {
        private CADPEntities db = new CADPEntities();

        public JsonResult GetLGAs(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            IEnumerable<tbl_LK_Lga> states = db.tbl_LK_Lga.Where(stat => stat.StateID == id);
            return Json(states);
        }

        // GET: MarketList
        public ActionResult Index()
        {
            var tbl_LK_MarketList = db.tbl_LK_MarketList.Include(t => t.tbl_LK_Lga).Include(t => t.tbl_LK_State);
            return View(tbl_LK_MarketList.ToList());
        }

        // GET: MarketList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketList tbl_LK_MarketList = db.tbl_LK_MarketList.Find(id);
            if (tbl_LK_MarketList == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketList);
        }

        // GET: MarketList/Create
        public ActionResult Create()
        {
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
            return View();
        }

        // POST: MarketList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketListID,MarketListName,StateID,LgaID,MarketAddres,Longitude,Latitude,location")] tbl_LK_MarketList tbl_LK_MarketList)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_MarketList.Add(tbl_LK_MarketList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_MarketList.LgaID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_MarketList.StateID);
            return View(tbl_LK_MarketList);
        }


        public JsonResult GetLGAName(string id)
        {
            if (id == null)
            {
                id = "0";
            }


            var stateId = Convert.ToInt32(id);


            //AllSampleCodeEntities objord = new AllSampleCodeEntities();

            var response = (from slist in db.tbl_LK_Lga
                            where (slist.StateID == stateId)
                            select new { slist.LgaID, slist.LgaName }).ToList();

            return Json(new SelectList(response, "LgaID", "LgaName"));
        }
        // GET: MarketList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketList tbl_LK_MarketList = db.tbl_LK_MarketList.Find(id);
            if (tbl_LK_MarketList == null)
            {
                return HttpNotFound();
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_MarketList.LgaID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_MarketList.StateID);
            return View(tbl_LK_MarketList);
        }

        // POST: MarketList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketListID,MarketListName,StateID,LgaID,MarketAddres,Longitude,Latitude,location")] tbl_LK_MarketList tbl_LK_MarketList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_MarketList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_LK_MarketList.LgaID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_LK_MarketList.StateID);
            return View(tbl_LK_MarketList);
        }

        // GET: MarketList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_MarketList tbl_LK_MarketList = db.tbl_LK_MarketList.Find(id);
            if (tbl_LK_MarketList == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_MarketList);
        }

        // POST: MarketList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_MarketList tbl_LK_MarketList = db.tbl_LK_MarketList.Find(id);
            db.tbl_LK_MarketList.Remove(tbl_LK_MarketList);
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

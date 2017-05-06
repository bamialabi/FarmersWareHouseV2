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
    public class MarketInformationController : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: MarketInformation
        public JsonResult GetMarketName(string id)
        {
            if (id == null)
            {
                id = "0";
            }


            var stateId = Convert.ToInt32(id);


            //AllSampleCodeEntities objord = new AllSampleCodeEntities();

            var response = (from slist in db.tbl_LK_MarketList
                            where (slist.StateID == stateId)
                            select new { slist.MarketListID, slist.MarketListName }).ToList();

            return Json(new SelectList(response, "MarketListID", "MarketListName"));
        }

        public ActionResult MarketMenu()
        {
            return View();
        }
        public ActionResult Index()
        {
            var tbl_MarketInformation = db.tbl_MarketInformation.Include(t => t.tbl_LK_Lga).Include(t => t.tbl_LK_Marketer).Include(t => t.tbl_LK_MarketList).Include(t => t.tbl_LK_MarketProduct).Include(t => t.tbl_LK_MarketUnitOfMeaure).Include(t => t.tbl_LK_State).Include(t => t.tbl_LK_Marketer );
            return View(tbl_MarketInformation.ToList());
        }

        // GET: MarketInformation/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MarketInformation tbl_MarketInformation = db.tbl_MarketInformation.Find(id);
            if (tbl_MarketInformation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MarketInformation);
        }

        // GET: MarketInformation/Create
        public ActionResult Create()
        {
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName");
            ViewBag.MarketerID = new SelectList(db.tbl_LK_Marketer, "MarketerID", "MarketerName");
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName");
            ViewBag.ProductID = new SelectList(db.tbl_LK_MarketProduct, "ProductID", "ProductName");
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName");
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");

            ViewBag.OfferID = new SelectList(db.tbl_LK_OfferTypes, "OfferID", "OfferDescription");
            return View();
        }

        // POST: MarketInformation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarketInfoID,MarketListID,MarketerID,ProductID,ProductDescription,QuantityForSale,Price,AvalabilityStatus,UnitOfMeasureID,LgaID,StateID")] tbl_MarketInformation tbl_MarketInformation)
        {
            if (ModelState.IsValid)
            {
                db.tbl_MarketInformation.Add(tbl_MarketInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_MarketInformation.LgaID);
            ViewBag.MarketerID = new SelectList(db.tbl_LK_Marketer, "MarketerID", "MarketerName", tbl_MarketInformation.MarketerID);
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_MarketInformation.MarketListID);
            ViewBag.ProductID = new SelectList(db.tbl_LK_MarketProduct, "ProductID", "ProductName", tbl_MarketInformation.ProductID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_MarketInformation.UnitOfMeasureID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_MarketInformation.StateID);
            
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName",tbl_MarketInformation.OfferID);

            return View(tbl_MarketInformation);
        }

        // GET: MarketInformation/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MarketInformation tbl_MarketInformation = db.tbl_MarketInformation.Find(id);
            if (tbl_MarketInformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_MarketInformation.LgaID);
            ViewBag.MarketerID = new SelectList(db.tbl_LK_Marketer, "MarketerID", "MarketerName", tbl_MarketInformation.MarketerID);
            ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_MarketInformation.MarketListID);
            ViewBag.ProductID = new SelectList(db.tbl_LK_MarketProduct, "ProductID", "ProductName", tbl_MarketInformation.ProductID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_MarketInformation.UnitOfMeasureID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_MarketInformation.StateID);
            return View(tbl_MarketInformation);
        }

        // POST: MarketInformation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarketInfoID,MarketListID,MarketerID,ProductID,ProductDescription,QuantityForSale,Price,AvalabilityStatus,UnitOfMeasureID,LgaID,StateID")] tbl_MarketInformation tbl_MarketInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_MarketInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LgaID = new SelectList(db.tbl_LK_Lga, "LgaID", "LgaName", tbl_MarketInformation.LgaID);
            ViewBag.MarketerID = new SelectList(db.tbl_LK_Marketer, "MarketerID", "MarketerName", tbl_MarketInformation.MarketerID);
            //ViewBag.MarketListID = new SelectList(db.tbl_LK_MarketList, "MarketListID", "MarketListName", tbl_MarketInformation.MarketListID);
            ViewBag.ProductID = new SelectList(db.tbl_LK_MarketProduct, "ProductID", "ProductName", tbl_MarketInformation.ProductID);
            ViewBag.UnitOfMeasureID = new SelectList(db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", tbl_MarketInformation.UnitOfMeasureID);
            ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName", tbl_MarketInformation.StateID);
            return View(tbl_MarketInformation);
        }

        // GET: MarketInformation/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_MarketInformation tbl_MarketInformation = db.tbl_MarketInformation.Find(id);
            if (tbl_MarketInformation == null)
            {
                return HttpNotFound();
            }
            return View(tbl_MarketInformation);
        }

        // POST: MarketInformation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            tbl_MarketInformation tbl_MarketInformation = db.tbl_MarketInformation.Find(id);
            db.tbl_MarketInformation.Remove(tbl_MarketInformation);
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

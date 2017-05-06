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
    public class FarmValueChain2Controller : Controller
    {
        private CADPEntities db = new CADPEntities();

        // GET: FarmValueChain2
        public ActionResult Index()
        {
            return View(db.tbl_LK_FarmValueChain.ToList());
        }

        // GET: FarmValueChain2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmValueChain tbl_LK_FarmValueChain = db.tbl_LK_FarmValueChain.Find(id);
            if (tbl_LK_FarmValueChain == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmValueChain);
        }

        // GET: FarmValueChain2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmValueChain2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValueChainID,ValueChainName")] tbl_LK_FarmValueChain tbl_LK_FarmValueChain)
        {
            if (ModelState.IsValid)
            {
                db.tbl_LK_FarmValueChain.Add(tbl_LK_FarmValueChain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_LK_FarmValueChain);
        }

        // GET: FarmValueChain2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmValueChain tbl_LK_FarmValueChain = db.tbl_LK_FarmValueChain.Find(id);
            if (tbl_LK_FarmValueChain == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmValueChain);
        }

        // POST: FarmValueChain2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValueChainID,ValueChainName")] tbl_LK_FarmValueChain tbl_LK_FarmValueChain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_LK_FarmValueChain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_LK_FarmValueChain);
        }

        // GET: FarmValueChain2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_LK_FarmValueChain tbl_LK_FarmValueChain = db.tbl_LK_FarmValueChain.Find(id);
            if (tbl_LK_FarmValueChain == null)
            {
                return HttpNotFound();
            }
            return View(tbl_LK_FarmValueChain);
        }

        // POST: FarmValueChain2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_LK_FarmValueChain tbl_LK_FarmValueChain = db.tbl_LK_FarmValueChain.Find(id);
            db.tbl_LK_FarmValueChain.Remove(tbl_LK_FarmValueChain);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FarmersWareHouse.ViewModel;
using Core.DataAccess;

namespace FarmersWareHouse.Controllers
{
    public class MKTDropDownListController : Controller
    {
        // GET: MKTDropDownList
        CADPEntities _db = new CADPEntities();
        public ActionResult Index()
        {
            List<SelectListItem> stateNames = new List<SelectListItem>();
            MarketerModel marketMDL = new MarketerModel();

            List<tbl_LK_State> states = _db.tbl_LK_State.ToList();
            states.ForEach(x =>
                {
                    stateNames.Add(new SelectListItem { Text = x.StateName, Value = x.StateID.ToString() });
                });
            marketMDL.LK_StateName = stateNames;

            return View(marketMDL);
        }

        [HttpPost]
        public ActionResult Index(string stateID)
        {
            int statID;
            List<SelectListItem> lgaNames = new List <SelectListItem>();
            if (!string.IsNullOrEmpty(stateID))
            {
                statID = Convert.ToInt32(stateID);
                List<tbl_LK_Lga> lga = _db.tbl_LK_Lga.ToList();
                lga.ForEach(X =>
                {
                    lgaNames.Add(new SelectListItem { Text = X.LgaName, Value = X.LgaID.ToString() });
                });
                return Json(lgaNames, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
        // GET: MKTDropDownList/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MKTDropDownList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MKTDropDownList/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MKTDropDownList/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MKTDropDownList/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MKTDropDownList/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MKTDropDownList/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

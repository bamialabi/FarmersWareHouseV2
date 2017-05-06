using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.DataAccess;

namespace FarmersWareHouse.Controllers
{
    public class SettingsController : Controller
    {
        readonly CADPEntities _db = new CADPEntities();
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarmMenu()
        {
            return View();
        }
        #region INDICATOR
        public ActionResult IndicatorListing()
        {
            return View(_db.tbl_LK_ME_Indicator.ToList());
        }
        public ActionResult AddIndicator()
        {
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");
            return View();
        }
        [HttpPost]
        public ActionResult AddIndicator(tbl_LK_ME_Indicator model)
        {
            //id is SubComponentID 
            var isExist =
                (from c in _db.tbl_LK_ME_Indicator where c.IndicatorName == model.IndicatorName select c).SingleOrDefault
                    ();
            if (isExist == null)
            {
                var obj = new tbl_LK_ME_Indicator
                {
                    SubComponentID = model.SubComponentID,
                    IndicatorName = model.IndicatorName
                };
                ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentID);
                _db.tbl_LK_ME_Indicator.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index", new { msg = "Action was successful." });
            }
            else
            {
                return Content("Error was on page or that was a duplicate entry. Go back and try again.");
            }
        }
        public ActionResult DeleteIndicator(short id)
        {
            var x = (from c in _db.tbl_LK_ME_Indicator where c.IndicatorsID == id select c).FirstOrDefault();
            _db.tbl_LK_ME_Indicator.Remove(x);
            _db.SaveChanges();
            return RedirectToAction("IndicatorListing");
        }

        #endregion


        #region INDICATOR REGISTER
        public ActionResult NewIndicatorRegister()
        {
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");
            ViewBag.IndicatorsID = new SelectList(_db.tbl_LK_ME_Indicator, "IndicatorsID", "IndicatorName");
            ViewBag.UnitOfMeasureID = new SelectList(_db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName");
            return View();
        }
        [HttpPost]
        public ActionResult NewIndicatorRegister(tbl_ME_LK_IndicatorRegister model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = new tbl_ME_LK_IndicatorRegister
                    {
                        IndicatorsID = model.IndicatorsID,
                        SubComponentID = model.SubComponentID,
                        IndicatorName = model.IndicatorName,
                        UnitOfMeasureID = model.UnitOfMeasureID,
                        Summable = model.Summable
                    };
                    _db.tbl_ME_LK_IndicatorRegister.Add(obj);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return Content("An Error Occured " + ex.Message);
            }
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentID);
            ViewBag.IndicatorsID = new SelectList(_db.tbl_LK_ME_Indicator, "IndicatorsID", "IndicatorName", model.IndicatorsID);
            ViewBag.UnitOfMeasureID = new SelectList(_db.tbl_LK_MarketUnitOfMeaure, "UnitOfMeasureID", "UnitOfMeasureName", model.UnitOfMeasureID);
            return View();
        }
        #endregion

        
    }
}
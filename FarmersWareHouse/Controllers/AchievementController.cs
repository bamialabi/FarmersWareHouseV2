using Core.DataAccess;
using FarmersWareHouse.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersWareHouse.Controllers
{
    public class AchievementController : Controller
    {

        // GET: Achievement
        readonly CADPEntities _db = new CADPEntities();

        public JsonResult GetCigName(string id)
        {
            if (id == null)
            {
                id = "0";
            }


            var stateId = Convert.ToInt32(id);


            //AllSampleCodeEntities objord = new AllSampleCodeEntities();

            var response = (from slist in _db.tbl_LK_FarmerCIG
                            where (slist.StateID == stateId)
                            select new { slist.CIGID, slist.CIGName }).ToList();

            return Json(new SelectList(response, "CIGID", "CIGName"));
        }
        public ActionResult Index()
        {
            return View(_db.tbl_ME_RegisterIndicatorAchievement.ToList());
        }

        public ActionResult AddAchievement()
        {
            var obj = new RegisterAchievement
            {
                IndicatorRegister = _db.tbl_ME_LK_IndicatorRegister.Take(1)
            };
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");
            ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            ViewBag.ProductionSeasonID = new SelectList(_db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");
            ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year");
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddAchievement(RegisterTargetIndicator model, string submit)
        {
            var rex = 0;
            var x = (from c in _db.tbl_ME_LK_IndicatorRegister where c.SubComponentID == model.SubComponentId select c).ToList();
            var obj = new RegisterAchievement
            {
                IndicatorRegister = x.ToList(),
                SubComponentId = model.SubComponentId,
                StateID = model.StateId,
                CIGID = model.CigId,
                ProductionSeasonID = model.ProductionSeasonId,
                YearID = model.YearId,
                Approved = false,
                DateCreated = DateTime.Now
            };
            switch (submit)
            {
                case "Search":
                    //ViewBag.Message = "Customer saved successfully!";
                    ViewBag.ProductionSeasonID = new SelectList(_db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", model.ProductionSeasonId);
                    ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year", model.YearId);
                    ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentId);
                    ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", model.StateId);
                    ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", model.CigId);
                    return View(obj);
                case "Process":
                    foreach (var item in x)
                    {

                        var ob = new tbl_ME_RegisterIndicatorAchievement
                        {
                            RegisterIndicatorsID = item.RegisterIndicatorsID,
                            StateID = model.StateId,
                            CIGID = model.CigId,
                            AchievementData = 0m,
                            ProductionSeasonID = model.ProductionSeasonId,
                            YearID = model.YearId,
                            DateCreated = DateTime.Now,
                            Approved = false,
                            //Remarks = item.Remark,
                            Quarter = 1
                        };
                        _db.tbl_ME_RegisterIndicatorAchievement.Add(ob);
                        _db.SaveChanges();
                        rex = model.CigId;

                    }
                    ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentId);
                    ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", model.StateId);
                    ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", model.CigId);
                    ViewBag.ProductionSeasonID = new SelectList(_db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", model.ProductionSeasonId);
                    ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year", model.YearId);
                    return RedirectToAction("AchievementListing", new { id = rex, year = model.YearId });
            }

            return View();
        }
        public ActionResult AchievementListing(int id, short year)
        {
            var x = (from c in _db.tbl_ME_RegisterIndicatorAchievement where c.CIGID == id && c.YearID == year select c).ToList();
            return View(x);
        }
        [HttpPost]
        public ActionResult AchievementListing(FormCollection c)
        {
            var i = 0;
            if (ModelState.IsValid)
            {
                var userIdArray = c.GetValues("item.AchievementID");
                var baseDataArray = c.GetValues("item.AchievementData");
                var rmData = c.GetValues("item.Remarks");

                for (i = 0; i < userIdArray.Count(); i++)
                {
                    var baseData = _db.tbl_ME_RegisterIndicatorAchievement.Find(Convert.ToInt32(userIdArray[i]));
                    baseData.AchievementData = Convert.ToDecimal(baseDataArray[i]);
                    //baseData.Remarks = rmData[i];
                    _db.Entry(baseData).State = EntityState.Modified;
                }
                _db.SaveChanges();
            }
            return Content("Success!!");
        }
        public ActionResult TargetIndicatorListing(FormCollection c)
        {
            var i = 0;
            if (ModelState.IsValid)
            {
                var userIdArray = c.GetValues("item.TargetID");
                var baseDataArray = c.GetValues("item.TargetData");

                for (i = 0; i < userIdArray.Count(); i++)
                {
                    var baseData = _db.tbl_ME_RegisterIndicatorTarget.Find(Convert.ToInt32(userIdArray[i]));
                    baseData.TargetData = Convert.ToDecimal(baseDataArray[i]);
                    _db.Entry(baseData).State = EntityState.Modified;
                }
                _db.SaveChanges();
            }
            return Content("Success!!");
        }

        public ActionResult Edit(int id)
        {
            var x = (from c in _db.tbl_ME_RegisterIndicatorAchievement where c.AchievementID == id select c).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(tbl_ME_RegisterIndicatorAchievement model)
        {
            var x = (from c in _db.tbl_ME_RegisterIndicatorAchievement where c.AchievementID == model.AchievementID select c).FirstOrDefault();
            x.AchievementData = model.AchievementData;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
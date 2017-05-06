using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.DataAccess;
using FarmersWareHouse.ViewModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace FarmersWareHouse.Controllers
{
    public class BaselinesController : Controller
    {
        readonly CADPEntities _db = new CADPEntities();
        // GET: Baselines
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddNewBaseline()
        {
            var obj = new RegisterBaseLineViewModel
            {
                IndicatorRegister = _db.tbl_ME_LK_IndicatorRegister.Take(10)
            };
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");
            ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddNewBaseline(RegisterBaseLineViewModel model, string submit)
        {
            var rex = 0;
            var x = (from c in _db.tbl_ME_LK_IndicatorRegister where c.SubComponentID == model.SubComponentId select c).ToList();
            var obj = new RegisterBaseLineViewModel
            {
                IndicatorRegister = x.Take(10),
                SubComponentId = model.SubComponentId,
                StateId = model.StateId,
                CigId = model.CigId
            };
            switch (submit)
            {
                case "Search":
                    //ViewBag.Message = "Customer saved successfully!";
                    ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentId);
                    ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", model.StateId);
                    ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", model.CigId);
                    return View(obj);
                case "Process":
                    foreach (var item in x)
                    {

                        var baseline = new tbl_ME_Baseline
                        {
                            RegisterIndicatorsID = item.RegisterIndicatorsID,
                            StateID = model.StateId,
                            CIGID = model.CigId,
                            BaseData = 0m
                        };


                        _db.tbl_ME_Baseline.Add(baseline);
                        _db.SaveChanges();
                        rex = model.CigId;

                    }
                    ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentId);
                    ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", model.StateId);
                    ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", model.CigId);
                    return RedirectToAction("BaseLineListing", new { id = rex });
            }

            return View();
        }

        public ActionResult BaseLineListing(int id)
        {
            var x = (from c in _db.tbl_ME_Baseline where c.CIGID == id select c).ToList();
            return View(x);
        }
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BaseLineListing(FormCollection c)
        {
            var i = 0;
            if (ModelState.IsValid)
            {
                var userIdArray = c.GetValues("item.BaselineID");
                var baseDataArray = c.GetValues("item.BaseData");

                for (i = 0; i < userIdArray.Count(); i++)
                {
                    var baseData = _db.tbl_ME_Baseline.Find(Convert.ToInt32(userIdArray[i]));
                    baseData.BaseData = Convert.ToDecimal(baseDataArray[i]);
                    _db.Entry(baseData).State = EntityState.Modified;
                }
                _db.SaveChanges();
            }
            return Content("Success!!");
        }

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

        public ActionResult BaselineList()
        {
            ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            return View(_db.tbl_ME_Baseline.ToList());

        }
        [HttpPost]
        public ActionResult BaselineList(short stateId, short cigId)
        {
            var x = (from c in _db.tbl_ME_Baseline where c.StateID == stateId && c.CIGID == cigId select c).ToList();
            ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", stateId);
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", cigId);
            return View(x);

        }
        public ActionResult ExportData()
        {
            String constring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constring);
            string query = "SELECT B.CIGName,  C.ProductionSeasonName, D.Year, E.IndicatorName, A.TargetData FROM [tbl_ME_RegisterIndicatorTarget] A INNER JOIN [tbl_LK_FarmerCIG] B ON A.CIGID = B.CIGID INNER JOIN " +
                "[tbl_LK_FarmerProductionSeason] C ON A.ProductionSeasonID = C.ProductionSeasonID INNER JOIN [tbl_LK_Year] D ON A.YearID = D.YearID INNER JOIN [tbl_ME_LK_IndicatorRegister] E On A.RegisterIndicatorsID = E.RegisterIndicatorsID";
            DataTable dt = new DataTable();
            dt.TableName = "Employee";
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wb.Style.Font.Bold = true;

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename= EmployeeReport.xlsx");

                using (MemoryStream MyMemoryStream = new MemoryStream())
                {
                    wb.SaveAs(MyMemoryStream);
                    MyMemoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
            return RedirectToAction("Index", "ExportData");
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public ActionResult Edit(int id)
        {
            var x = (from c in _db.tbl_ME_Baseline where c.BaseLineID == id select c).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(tbl_ME_Baseline model)
        {
            var x = (from c in _db.tbl_ME_Baseline where c.BaseLineID == model.BaseLineID select c).FirstOrDefault();
            x.BaseData = model.BaseData;
            _db.SaveChanges();
            return RedirectToAction("BaselineList");
        }
    }
}
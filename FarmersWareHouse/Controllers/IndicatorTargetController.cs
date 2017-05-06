
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.DataAccess;
using FarmersWareHouse.ViewModel;
using System.Configuration;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;
using System.Data;

namespace FarmersWareHouse.Controllers
{
    public class IndicatorTargetController : Controller
    {
        readonly CADPEntities _db = new CADPEntities();
        // GET: IndicatorTarget
        public ActionResult Index(string search)
        {
            //Complete code for seach and sort and pagination
            return View(_db.tbl_ME_RegisterIndicatorTarget.ToList());
        }

        public ActionResult AddTargetIndicator()
        {
            var obj = new RegisterTargetIndicator
            {
                IndicatorRegister = _db.tbl_ME_LK_IndicatorRegister.Take(10)
            };
            ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName");
            ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
            ViewBag.ProductionSeasonID = new SelectList(_db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");
            ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year");
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddTargetIndicator(RegisterTargetIndicator model, string submit)
        {
            var rex = 0;
            var x = (from c in _db.tbl_ME_LK_IndicatorRegister where c.SubComponentID == model.SubComponentId select c).ToList();
            var obj = new RegisterTargetIndicator
            {
                IndicatorRegister = x.ToList(),
                SubComponentId = model.SubComponentId,
                StateId = model.StateId,
                CigId = model.CigId,
                ProductionSeasonId = model.ProductionSeasonId,
                YearId = model.YearId
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
                    return  View(obj);
                case "Process":
                    foreach (var item in x)
                    {

                        var ob = new tbl_ME_RegisterIndicatorTarget
                        {
                            RegisterIndicatorsID = item.RegisterIndicatorsID,
                            StateID = model.StateId,
                            CIGID = model.CigId,
                            TargetData = 0m,
                            ProductionSeasonID = model.ProductionSeasonId,
                            YearID = model.YearId,
                            DateCreated = DateTime.Now,
                            Approved = false
                        };
                        _db.tbl_ME_RegisterIndicatorTarget.Add(ob);
                        _db.SaveChanges();
                        rex = model.CigId;

                    }
                    ViewBag.SubComponentID = new SelectList(_db.tbl_LK_ME_SubComponent, "SubComponentID", "SubComponentName", model.SubComponentId);
                    ViewBag.StateID = new SelectList(_db.tbl_LK_State, "StateID", "StateName", model.StateId);
                    ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName", model.CigId);
                    ViewBag.ProductionSeasonID = new SelectList(_db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName", model.ProductionSeasonId);
                    ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year", model.YearId);
                    return RedirectToAction("TargetIndicatorListing", new { id = rex, year = model.YearId });
            }

            return View();
        }

        public ActionResult TargetIndicatorListing(int id, short year)
        {
            var x = (from c in _db.tbl_ME_RegisterIndicatorTarget where c.CIGID == id && c.YearID == year select c).ToList();
            return View(x);
        }
        [HttpPost]
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
            var x = (from c in _db.tbl_ME_RegisterIndicatorTarget where c.TargetID == id select c).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult Edit(tbl_ME_RegisterIndicatorTarget model)
        {
            var x = (from c in _db.tbl_ME_RegisterIndicatorTarget where c.TargetID == model.TargetID select c).FirstOrDefault();
            x.TargetData = model.TargetData;
            _db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}
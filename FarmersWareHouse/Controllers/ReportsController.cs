using ClosedXML.Excel;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersWareHouse.Controllers
{
    public class ReportsController : Controller
    {
        readonly CADPEntities _db = new CADPEntities();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
        
            var data = (from c in _db.tbl_ME_RegisterIndicatorAchievement
                        join d in _db.tbl_ME_RegisterIndicatorTarget on c.CIGID equals d.CIGID
                      
                        select new ViewModel
                        {
                            TargetData = d.TargetData,
                            AchievementData = c.AchievementData,
                            Percentage = 100,
                            RegisterIndicatorIds = c.tbl_ME_LK_IndicatorRegister.IndicatorName
                        }).ToList();
            ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");

            return View(data);
        }
        [HttpPost]
        public ActionResult GetData(int? cigId, int? yearId)
        {
            var data = (from c in _db.tbl_ME_RegisterIndicatorAchievement
                        join d in _db.tbl_ME_RegisterIndicatorTarget on c.CIGID equals d.CIGID
                        where c.CIGID == cigId && c.YearID == yearId
                        select new ViewModel
                        {
                            TargetData = d.TargetData,
                            AchievementData = c.AchievementData,
                            Percentage = 100,
                            RegisterIndicatorIds = c.tbl_ME_LK_IndicatorRegister.IndicatorName
                        }).ToList();
            ViewBag.YearID = new SelectList(_db.tbl_LK_Year, "YearID", "Year");
            ViewBag.CIGID = new SelectList(_db.tbl_LK_FarmerCIG, "CIGID", "CIGName");

            return View(data);
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

        public class ViewModel
        {
            public int CIGID { get; set; }
            public int Year { get; set; }
            public decimal? TargetData { get; set; }
            public decimal? AchievementData { get; set; }
            public int RegisterIndicatorId { get; set; }

            public string RegisterIndicatorIds { get; set; }
            public decimal Percentage { get; set; }
            public virtual tbl_ME_RegisterIndicatorTarget Target { get; set; }
            public virtual tbl_LK_FarmerCIG Farmer { get; set; }
        }
    }
}
using Core.DataAccess;
using FarmersWareHouse.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmersWareHouse.Controllers
{
    public class FarmRecordController : Controller
    {
        // GET: FarmRecord
        CADPEntities db = new CADPEntities();
        public ActionResult Index(int? id, int? ssId)
        {
            //id = 1;
            //  ssId = 1;

              ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
              ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
              ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");
          
            var response = new Salem
            {
                Benefits = (from c in db.tbl_LK_FarmerBenefit where c.CIGID == id && c.ProductionSeasonID==ssId select c).ToList(),
                Production = (from c in db.tbl_LK_FarmerProduction where c.CIGID == id && c.ProductionSeasonID == ssId select c).ToList(),
                Famer=(from c in db.tbl_LK_Farmer select c).ToList()
                
            };
            return View(response);
        }
        //[HttpPost]
        //public ActionResult Index(int? id, int? ssId)
        //{
        //    id = 1;
        //    ssId = 1;

        //    ViewBag.CIGID = new SelectList(db.tbl_LK_FarmerCIG, "CIGID", "CIGName");
        //    ViewBag.StateID = new SelectList(db.tbl_LK_State, "StateID", "StateName");
        //    ViewBag.ProductionSeasonID = new SelectList(db.tbl_LK_FarmerProductionSeason, "ProductionSeasonID", "ProductionSeasonName");

        //    var response = new Salem
        //    {
        //        Benefits = (from c in db.tbl_LK_FarmerBenefit where c.CIGID == id && c.ProductionSeasonID == ssId select c).ToList(),
        //        Production = (from c in db.tbl_LK_FarmerProduction where c.CIGID == id && c.ProductionSeasonID == ssId select c).ToList(),
        //        Famer = (from c in db.tbl_LK_Farmer select c).ToList()

        //    };
        //    return View(response);
        //}
        
        
        
        public class Salem
        {
           
            public List<tbl_LK_Farmer> Famer { get; set; }
            public List<tbl_LK_FarmerBenefit> Benefits { get; set; }
            public List<tbl_LK_FarmerProduction> Production { get; set; }
            //public List<tbl_LK_FarmerCIG> FarmerCIG { get; set; }
            //public List<tbl_LK_State> States { get; set; }
            public int StateId { get; set; }
            public int CigId { get; set; }
            public short SubComponentId { get; set; }
            public short ProductionSeasonId { get; set; }


        }
    }
}
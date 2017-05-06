using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  Core;
using Core.DataAccess;

namespace FarmersWareHouse.ViewModel
{

    public class FarmerVModel
    {
        CADPEntities _db = new CADPEntities();
        //public string  FarmerName { get; set; }
        //public string MobileNo1 { get; set; }
        //public decimal  Amount { get; set; }
        //public decimal Quantity_10_11 { get; set; }
        //public string CIGName { get; set; }
       
       
        public List<tbl_LK_Farmer> Famer { get; set; }
        public List<tbl_LK_FarmerBenefit> Benefits { get; set; }
        public List<tbl_LK_FarmerProduction> Production { get; set; }
    }
}
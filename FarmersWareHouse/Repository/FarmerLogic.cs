using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DataAccess;
using System.Collections;
using FarmersWareHouse.ViewModel;

namespace FarmersWareHouse.Repository
{
    public class FarmerLogic
    {
        CADPEntities db = new CADPEntities();
        public IEnumerable<object> GetProduction() 
        {
            var farmerRecord = from f in db.tbl_LK_Farmer
                               join p in db.tbl_LK_FarmerProduction on f.FarmerID equals p.FarmerID
                               join b in db.tbl_LK_FarmerBenefit on f.FarmerID equals b.FarmerID
                               join c in db.tbl_LK_FarmerCIG on f.CIGID equals c.CIGID
                               select new
                               {
                                   f.FarmerName,
                                   f.MobileNo1,
                                   b.Amount,
                                   p.Quantity_10_11,
                                   c.CIGName
                               };
            return farmerRecord.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core;
using Core.DataAccess;
using System.Web.Mvc;
namespace FarmersWareHouse.ViewModel
{
    public class MarketerModel
    {
            //public tbl_LK_Marketer()
            //{
            //    this.tbl_MarketInformation = new HashSet<tbl_MarketInformation>();
            //}
        CADPEntities _db =new CADPEntities();

            public int MarketerID { get; set; }
            public Nullable<int> MarketListID { get; set; }
            public string MarketerName { get; set; }
            public Nullable<int> Introducer { get; set; }
            public Nullable<int> StateID { get; set; }
            public Nullable<int> LgaID { get; set; }
            public string MarketAddress { get; set; }
            public decimal Longitude { get; set; }
            public Nullable<decimal> Latitude { get; set; }
            public string Location { get; set; }
            public string MobileNo { get; set; }

            public IList<SelectListItem> LK_LgaName { get; set; }
            public IList<SelectListItem> tbl_LK_MarketList { get; set; }
            public IList<SelectListItem> LK_StateName { get; set; }
          //  public IEnumerable< ICollection<tbl_MarketInformation> tbl_MarketInformation { get; set; }
        }
    }



//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_FarmPoulty
    {
        public int FarmFishID { get; set; }
        public Nullable<int> FarmerID { get; set; }
        public Nullable<int> ProductionSeasonID { get; set; }
        public Nullable<decimal> Qty_Produced { get; set; }
        public Nullable<int> FarmProductID { get; set; }
    
        public virtual tbl_LK_Farmer tbl_LK_Farmer { get; set; }
        public virtual tbl_LK_FarmerProductionSeason tbl_LK_FarmerProductionSeason { get; set; }
        public virtual tbl_LK_FarmProduct tbl_LK_FarmProduct { get; set; }
    }
}

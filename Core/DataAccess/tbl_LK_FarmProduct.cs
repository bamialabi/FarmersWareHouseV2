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
    
    public partial class tbl_LK_FarmProduct
    {
        public tbl_LK_FarmProduct()
        {
            this.tbl_FarmAcquaculture = new HashSet<tbl_FarmAcquaculture>();
            this.TBL_FarmPoulty = new HashSet<TBL_FarmPoulty>();
            this.tbl_LK_Farmer = new HashSet<tbl_LK_Farmer>();
        }
    
        public int FarmProductID { get; set; }
        public Nullable<int> FarmActivityID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> UnitOfMeasureID { get; set; }
        public string UnitOfMeasure { get; set; }
    
        public virtual ICollection<tbl_FarmAcquaculture> tbl_FarmAcquaculture { get; set; }
        public virtual ICollection<TBL_FarmPoulty> TBL_FarmPoulty { get; set; }
        public virtual tbl_LK_FarmActivity tbl_LK_FarmActivity { get; set; }
        public virtual ICollection<tbl_LK_Farmer> tbl_LK_Farmer { get; set; }
        public virtual tbl_LK_MarketUnitOfMeaure tbl_LK_MarketUnitOfMeaure { get; set; }
    }
}

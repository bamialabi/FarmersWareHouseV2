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
    
    public partial class tbl_LK_FarmActivity
    {
        public tbl_LK_FarmActivity()
        {
            this.tbl_LK_Farmer = new HashSet<tbl_LK_Farmer>();
            this.tbl_LK_FarmProduct = new HashSet<tbl_LK_FarmProduct>();
        }
    
        public int FarmActivityID { get; set; }
        public Nullable<int> ValueChainID { get; set; }
        public string FarmerActivityName { get; set; }
    
        public virtual tbl_LK_FarmValueChain tbl_LK_FarmValueChain { get; set; }
        public virtual ICollection<tbl_LK_Farmer> tbl_LK_Farmer { get; set; }
        public virtual ICollection<tbl_LK_FarmProduct> tbl_LK_FarmProduct { get; set; }
    }
}

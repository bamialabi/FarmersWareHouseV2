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
    
    public partial class tbl_LK_FarmSize
    {
        public tbl_LK_FarmSize()
        {
            this.tbl_LK_Farmer = new HashSet<tbl_LK_Farmer>();
        }
    
        public int FarmSizeID { get; set; }
        public string FarmSizeDescription { get; set; }
        public string Category { get; set; }
    
        public virtual ICollection<tbl_LK_Farmer> tbl_LK_Farmer { get; set; }
    }
}

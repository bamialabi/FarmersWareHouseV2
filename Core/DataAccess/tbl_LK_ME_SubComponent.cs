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
    
    public partial class tbl_LK_ME_SubComponent
    {
        public tbl_LK_ME_SubComponent()
        {
            this.ArtWorks = new HashSet<ArtWork>();
            this.tbl_LK_ME_Indicator = new HashSet<tbl_LK_ME_Indicator>();
            this.tbl_ME_LK_IndicatorRegister = new HashSet<tbl_ME_LK_IndicatorRegister>();
            this.tbl_ME_LK_IndicatorRegister1 = new HashSet<tbl_ME_LK_IndicatorRegister>();
        }
    
        public short SubComponentID { get; set; }
        public Nullable<short> ComponentID { get; set; }
        public string SubComponentName { get; set; }
    
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
        public virtual tbl_LK_ME_Component tbl_LK_ME_Component { get; set; }
        public virtual ICollection<tbl_LK_ME_Indicator> tbl_LK_ME_Indicator { get; set; }
        public virtual ICollection<tbl_ME_LK_IndicatorRegister> tbl_ME_LK_IndicatorRegister { get; set; }
        public virtual ICollection<tbl_ME_LK_IndicatorRegister> tbl_ME_LK_IndicatorRegister1 { get; set; }
    }
}

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
    
    public partial class tbl_LK_ME_Component
    {
        public tbl_LK_ME_Component()
        {
            this.tbl_LK_ME_SubComponent = new HashSet<tbl_LK_ME_SubComponent>();
        }
    
        public short ComponentID { get; set; }
        public string ComponentName { get; set; }
    
        public virtual ICollection<tbl_LK_ME_SubComponent> tbl_LK_ME_SubComponent { get; set; }
    }
}

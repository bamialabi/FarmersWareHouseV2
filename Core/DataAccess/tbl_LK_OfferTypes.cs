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
    
    public partial class tbl_LK_OfferTypes
    {
        public tbl_LK_OfferTypes()
        {
            this.tbl_MarketInformation = new HashSet<tbl_MarketInformation>();
        }
    
        public int OfferID { get; set; }
        public string OfferDescription { get; set; }
    
        public virtual ICollection<tbl_MarketInformation> tbl_MarketInformation { get; set; }
    }
}

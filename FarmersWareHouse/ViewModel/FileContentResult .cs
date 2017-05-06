using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DataAccess;

namespace FarmersWareHouse.ViewModel
{
    public partial class FileContentResult 
    {
        public int? fileID { get; set; }
        public string FileName { get; set; }
        public byte[] ArtworkThumbnail { get; set; }
        public byte[] ImageData { get; set; }
        public Nullable<int> CIGID { get; set; }
        public Nullable<short> SubComponentID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<long> ImageMimeType { get; set; }

        public virtual tbl_LK_FarmerCIG tbl_LK_FarmerCIG { get; set; }
        public virtual tbl_LK_ME_SubComponent tbl_LK_ME_SubComponent { get; set; }
        public virtual tbl_LK_State tbl_LK_State { get; set; }
    }
}
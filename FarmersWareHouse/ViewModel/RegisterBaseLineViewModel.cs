using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DataAccess;

namespace FarmersWareHouse.ViewModel
{
    public class RegisterBaseLineViewModel
    {
        public int RegisterIndicatorsId { get; set; }
        public int StateId { get; set; }
        public int CigId { get; set; }
        public short SubComponentId { get; set; }
        public decimal BaseData { get; set; }
        public string[] BaseValue { get; set; }
        public IEnumerable<tbl_ME_LK_IndicatorRegister> IndicatorRegister { get; set; }
    }
}
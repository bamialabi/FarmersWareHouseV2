using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DataAccess;

namespace FarmersWareHouse.ViewModel
{
    public class RegisterTargetIndicator
    {
        public int RegisterIndicatorsId { get; set; }
        public int StateId { get; set; }
        public int CigId { get; set; }
        public short SubComponentId { get; set; }
        public short ProductionSeasonId { get; set; }
        public short YearId { get; set; }
        public decimal TargetData { get; set; }
        public IEnumerable<tbl_ME_LK_IndicatorRegister> IndicatorRegister { get; set; }
    }

    public class RegisterAchievement
    {
        public int AchievementID { get; set; }
        public Nullable<int> RegisterIndicatorsID { get; set; }
        public Nullable<int> CIGID { get; set; }
        public Nullable<int> StateID { get; set; }
        public Nullable<int> ProductionSeasonID { get; set; }
        public Nullable<int> YearID { get; set; }
        public Nullable<decimal> AchievementData { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> Quarter { get; set; }
        public Nullable<bool> Approved { get; set; }
        public short SubComponentId { get; set; }
        public IEnumerable<tbl_ME_LK_IndicatorRegister> IndicatorRegister { get; set; }
    }
}
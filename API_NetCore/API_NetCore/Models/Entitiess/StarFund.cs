using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class StarFund
    {
        public long Id { get; set; }
        public int? YearFund { get; set; }
        public long TotalStar { get; set; }
        public long CurrentUseStar { get; set; }
        public DateTime CreateDtime { get; set; }
        public long CreateBy { get; set; }
        public DateTime? UpdateLudtime { get; set; }
        public long? UpdateLuby { get; set; }
        public bool IsActived { get; set; }
    }
}

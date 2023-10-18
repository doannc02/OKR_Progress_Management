﻿using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class CheckInScheduleFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? CheckInHistoryId { get; set; }
        public DateTime? LastTimeCheckIn { get; set; }
        public DateTime? NextTimeCheckIn { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullName { get; set; }
        public string MemberEmail { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public CheckInScheduleStatus? Status { get; set; }
    }
}

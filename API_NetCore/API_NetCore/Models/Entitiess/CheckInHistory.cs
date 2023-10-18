using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CheckInHistory
    {
        public long Id { get; set; }
        public long MemberId { get; set; }
        public string? MemberFullname { get; set; }
        public string? MemberEmail { get; set; }
        public int MemberGender { get; set; }
        public int MemberRole { get; set; }
        public long ManagerId { get; set; }
        public string? ManagerFullName { get; set; }
        public string? ManagerEmail { get; set; }
        public int MenberBeforeStar { get; set; }
        public int MenberAfterStar { get; set; }
        public int TotalStar { get; set; }
        public string? Cfrcomment { get; set; }
        public string? CfrcommentManager { get; set; }
        public int ConfidenceLevel { get; set; }
        public int MarkPoint { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? NextTime { get; set; }
        public byte Status { get; set; }
        public bool? IsActived { get; set; }
    }
}

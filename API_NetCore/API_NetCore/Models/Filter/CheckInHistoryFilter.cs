using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class CheckInHistoryFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public Gender? MemberGender { get; set; }
        public int? MemberRole { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public int? MenberBeforeStar { get; set; }
        public int? MenberAfterStar { get; set; }
        public int? TotalStar { get; set; }
        public string CFRComment { get; set; }
        public string CFRCommentManager { get; set; }
        public int? ConfidenceLevel { get; set; }
        public int? MarkPoint { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public CheckInHistoryType? Status { get; set; }
    }
}

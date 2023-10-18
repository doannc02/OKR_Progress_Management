using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class CheckInOKRFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? CheckInHistoryId { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public Gender? MemberGender { get; set; }
        public int? MemberRole { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public long? OKRId { get; set; }
        public string OKRName { get; set; }
        public int? OKRPercent { get; set; }
        public Status? OKRStatus { get; set; }
        public string CFRCommentOKR { get; set; }
        public string CommentOKR { get; set; }
        public int? ConfidenceLevel { get; set; }
        public long? CFRSuggestQuestionId { get; set; }
        public string Question { get; set; }
        public long? CFRSuggestAnswerId { get; set; }
        public string Answer { get; set; }
        public int? MarkPoint { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public CheckInHistoryType? Status { get; set; }
    }
}

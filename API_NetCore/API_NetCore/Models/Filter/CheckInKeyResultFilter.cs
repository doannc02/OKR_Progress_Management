using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class CheckInKeyResultFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? CheckInObjectiveId { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public Gender? MemberGender { get; set; }
        public int? MemberRole { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public long? KeyResultId { get; set; }
        public string KeyResultName { get; set; }
        public int? KeyResultPercent { get; set; }
        public Status? KeyResultStatus { get; set; }
        public long? QuarterId { get; set; }
        public string QuarterName { get; set; }
        public long? ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public int? ObjectivePercent { get; set; }
        public Status? ObjectiveStatus { get; set; }
        public string CFRCommentKR { get; set; }
        public string CommentKR { get; set; }
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

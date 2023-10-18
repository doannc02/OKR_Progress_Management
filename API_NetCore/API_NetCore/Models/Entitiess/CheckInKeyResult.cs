using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CheckInKeyResult
    {
        public long Id { get; set; }
        public long CheckInObjectiveId { get; set; }
        public long MemberId { get; set; }
        public string? MemberFullname { get; set; }
        public string? MemberEmail { get; set; }
        public int MemberGender { get; set; }
        public int MemberRole { get; set; }
        public long ManagerId { get; set; }
        public string? ManagerFullName { get; set; }
        public string? ManagerEmail { get; set; }
        public long KeyResultId { get; set; }
        public string? KeyResultName { get; set; }
        public int KeyResultPercent { get; set; }
        public byte KeyResultStatus { get; set; }
        public long ObjectiveId { get; set; }
        public string? ObjectiveName { get; set; }
        public int ObjectivePercent { get; set; }
        public byte ObjectiveStatus { get; set; }
        public string? CfrcommentKr { get; set; }
        public string? CommentKr { get; set; }
        public int ConfidenceLevel { get; set; }
        public int MarkPoint { get; set; }
        public long? CfrsuggestQuestionId { get; set; }
        public string? Question { get; set; }
        public long? CfrsuggestAnswerId { get; set; }
        public string? Answer { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? NextTime { get; set; }
        public byte Status { get; set; }
        public bool? IsActived { get; set; }
        public long? QuarterId { get; set; }
        public string? QuarterName { get; set; }
    }
}

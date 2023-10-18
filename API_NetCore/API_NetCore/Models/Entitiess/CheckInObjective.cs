using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CheckInObjective
    {
        public long Id { get; set; }
        public long CheckInOkrid { get; set; }
        public long MemberId { get; set; }
        public string? MemberFullname { get; set; }
        public string? MemberEmail { get; set; }
        public int MemberGender { get; set; }
        public int MemberRole { get; set; }
        public long ManagerId { get; set; }
        public string? ManagerFullName { get; set; }
        public string? ManagerEmail { get; set; }
        public long ObjectiveId { get; set; }
        public string? ObjectiveName { get; set; }
        public int ObjectivePercent { get; set; }
        public byte ObjectiveStatus { get; set; }
        public long Okrid { get; set; }
        public string? Okrname { get; set; }
        public int Okrpercent { get; set; }
        public byte Okrstatus { get; set; }
        public string? CfrcommentObj { get; set; }
        public string? CommentObj { get; set; }
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
    }
}

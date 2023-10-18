using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Request
{
    public class CheckInObjectiveRequestUpdate
    {
        public long Id { get; set; }
        public long CheckInOkrId { get; set; }
        public long MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public Gender MemberGender { get; set; }
        public int MemberRole { get; set; }
        public long ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public int ObjectivePercent { get; set; }
        public Status ObjectiveStatus { get; set; }
        public long OKRId { get; set; }
        public string OKRName { get; set; }
        public int OKRPercent { get; set; }
        public Status OKRStatus { get; set; }
        public int ConfidenceLevel { get; set; }
        public long CFRSuggestQuestionId { get; set; }
        public string Question { get; set; }
        public long CFRSuggestAnswerId { get; set; }
        public int MarkPoint { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextTime { get; set; }
        public CheckInHistoryType Status { get; set; }
        public bool IsActived { get; set; }
    }
}

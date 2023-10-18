using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Request
{    /// <summary>
     /// Table: CheckInKeyResult
     /// </summary>
    public class CheckInKeyResultRequestUpdate
    {
        public long Id { get; set; }
        public long CheckInObjectiveId { get; set; }
        public long MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public Gender MemberGender { get; set; }
        public int MemberRole { get; set; }
        public long KeyResultId { get; set; }
        public string KeyResultName { get; set; }
        public int KeyResultPercent { get; set; }
        public Status KeyResultStatus { get; set; }
        public long ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public int ObjectivePercent { get; set; }
        public Status ObjectiveStatus { get; set; }
        public string CommentKR { get; set; }
        public int ConfidenceLevel { get; set; }
        public string Question { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextTime { get; set; }
        public CheckInHistoryType Status { get; set; }
        public bool IsActived { get; set; }
    }
}

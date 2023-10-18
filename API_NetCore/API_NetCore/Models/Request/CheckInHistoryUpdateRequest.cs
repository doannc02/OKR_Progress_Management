using API_NetCore.Models.Entitiess;
using OKEA.Library.Models.Enums;
using System;
using System.Collections.Generic;

namespace OKEA.Library.Models.Request
{
    public class CheckInHistoryUpdate
    {
        public long Id { get; set; }
        public long? ManagerId { get; set; }
        public string Comment { get; set; }
        public string CFRComment { get; set; }
        public int? TotalStar { get; set; }
        public CheckInHistoryType? Status { get; set; }
    }
    public class CheckInDataUpdate
    {
        public long Id { get; set; }
        public long CheckInHistoryId { get; set; }
        public string Answer { get; set; }
    }
    public class CheckInHistoryUpdateDataRequest
    {
        public long? QuarterId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? NextTime { get; set; }
        public List<CheckInOkr> Okr { get; set; }
        public List<CheckInObjective> Objectives { get; set; }
        public List<CheckInKeyResult> KeyResults { get; set; }
    }
    // update CheckIn
    public class CheckInUpdate
    {
        public long? quarterId { get; set; }
        public long? MemberId { get; set; }
        public string Comment { get; set; }
        public string CFRComment { get; set; }
        public int? TotalStar { get; set; }
        public List<CheckInOkrUpdate> checkInOkr { get; set; }
        public List<CheckInObjectiveUpdate> checkInObj { get; set; }
        public List<CheckInKeyResultUpdate> checkInKr { get; set; }
    }
    public class CheckInOkrUpdate
    {
        public long Id { get; set; }
        public long? IdHistory { get; set; }
        public long OkrId { get; set; }
        public int Percent { get; set; }
        public string Answer { get; set; }
        public Status Status { get; set; }
    }
    public class CheckInObjectiveUpdate
    {
        public long Id { get; set; }
        public long ObjectiveId { get; set; }
        public string Comment { get; set; }
        public int Percent { get; set; }
        public string CFRComment { get; set; }
        public Status Status { get; set; }
    }
    public class CheckInKeyResultUpdate
    {
        public long Id { get; set; }
        public long KeyResultId { get; set; }
        public string Comment { get; set; }
        public int Percent { get; set; }
        public string CFRComment { get; set; }
        public Status Status { get; set; }
    }
}

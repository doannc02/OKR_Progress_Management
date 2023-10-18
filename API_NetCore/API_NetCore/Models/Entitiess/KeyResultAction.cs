using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class KeyResultAction
    {
        public long Id { get; set; }
        public long KeyResultId { get; set; }
        public string? KeyResultName { get; set; }
        public string? ActionName { get; set; }
        public int ActionPercent { get; set; }
        public long UserId { get; set; }
        public string? UserFullname { get; set; }
        public byte ObjectiveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Status { get; set; }
        public bool? IsActived { get; set; }
        public long? QuarterId { get; set; }
        public string? QuarterName { get; set; }
        public string? QuarterData { get; set; }
    }
}

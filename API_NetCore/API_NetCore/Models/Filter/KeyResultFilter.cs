using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class KeyResultFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? ObjectiveId { get; set; }
        public long? UserId { get; set; }
        public string KeyResultName { get; set; }
        public int? KeyResultPercent { get; set; }
        public string ObjectiveName { get; set; }
        public string UserFullname { get; set; }
        public ObjectiveType? ObjectiveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status? Status { get; set; }
        public long? QuarterId { get; set; }
        public string QuarterName { get; set; }
        public string QuarterData { get; set; }
    }
}

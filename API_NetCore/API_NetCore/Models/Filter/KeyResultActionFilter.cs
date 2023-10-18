using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class KeyResultActionFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? KeyResultId { get; set; }
        public long? UserId { get; set; }
        public string KeyResultName { get; set; }
        public string ActionName { get; set; }
        public int? ActionPercent { get; set; }
        public string UserFullname { get; set; }
        public ObjectiveType? ObjectType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status? Status { get; set; }
        public string QuarterData { get; set; }
    }
}

using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class ObjectiveFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? OkrId { get; set; }
        public long? UserId { get; set; }
        public string OkrName { get; set; }
        public string UserFullname { get; set; }
        public string ObjectiveName { get; set; }
        public int? ObjectivePercent { get; set; }
        public ObjectiveType? ObjectiveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status? Status { get; set; }
    }
}

using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Request
{
    public class KeyResultActionRequest
    {
        public long? Id { get; set; }
        public long? KeyResultId { get; set; }
        public long? UserId { get; set; }
        public string ActionName { get; set; }
        public int? ActionPercent { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status? Status { get; set; }
    }
}

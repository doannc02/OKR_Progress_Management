using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Request
{
    public class CheckInSearch
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public int? Percent { get; set; }
        public Status? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

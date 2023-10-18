using System;

namespace OKEA.Library.Models.Filter
{
    public class ElearningTestingResultFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserFullName { get; set; }
        public DateTime? TestingTime { get; set; }
        public int? NumberOfQuestion { get; set; }
        public int? TotalScore { get; set; }
    }
}

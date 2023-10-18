using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class QuarterFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public QuarterStatus? Status { get; set; }
    }
}

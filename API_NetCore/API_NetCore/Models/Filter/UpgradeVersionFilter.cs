using System;

namespace OKEA.Library.Models.Filter
{
    public class UpgradeVersionFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Version { get; set; }
        public string UpgradeNote { get; set; }
        public string BugFixedNote { get; set; }
        public DateTime? UpgradedDate { get; set; }
    }
}

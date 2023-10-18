using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class UpgradeVersion
    {
        public long Id { get; set; }
        public string Version { get; set; } = null!;
        public string? UpgradeNote { get; set; }
        public string? BugFixedNote { get; set; }
        public DateTime? UpgradedDate { get; set; }
        public bool? IsActived { get; set; }
    }
}

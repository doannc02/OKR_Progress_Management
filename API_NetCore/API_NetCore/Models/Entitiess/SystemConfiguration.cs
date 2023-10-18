using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class SystemConfiguration
    {
        public long Id { get; set; }
        public long ConfigTypeId { get; set; }
        public string ConfigType { get; set; } = null!;
        public string ConfigKey { get; set; } = null!;
        public string? ConfigValue { get; set; }
        public bool IsActived { get; set; }
        public string? Description { get; set; }
    }
}

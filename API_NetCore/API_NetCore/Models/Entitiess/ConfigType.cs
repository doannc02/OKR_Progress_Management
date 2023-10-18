using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ConfigType
    {
        public long Id { get; set; }
        public string Type { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActived { get; set; }
    }
}

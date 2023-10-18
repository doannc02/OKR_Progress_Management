using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningSetting
    {
        public long Id { get; set; }
        public int NumberOfQuestion { get; set; }
        public string? Description { get; set; }
        public bool? IsActived { get; set; }
    }
}

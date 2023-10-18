using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class TutorialType
    {
        public long Id { get; set; }
        public string TutorialType1 { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActived { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Quarter
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte? Status { get; set; }
        public bool? IsActived { get; set; }
    }
}

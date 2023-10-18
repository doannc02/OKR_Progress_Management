using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class DepartmentType
    {
        public long Id { get; set; }
        public string Type { get; set; } = null!;
        public string? Description { get; set; }
        public long ManagerId { get; set; }
        public string? ManagerType { get; set; }
        public bool IsActived { get; set; }
    }
}

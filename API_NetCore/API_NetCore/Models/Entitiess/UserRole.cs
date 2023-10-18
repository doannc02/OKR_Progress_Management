using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class UserRole
    {
        public long Id { get; set; }
        public long? DepartmentTypeId { get; set; }
        public string? DepartmentType { get; set; }
        public string? Role { get; set; }
        public bool IsActived { get; set; }
    }
}

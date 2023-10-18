using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Department
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
        public string? ParentName { get; set; }
        public long? ManagerId { get; set; }
        public string? ManagerFullName { get; set; }
        public string? ManagerEmail { get; set; }
        public string? ManagerLoginName { get; set; }
        public bool IsActived { get; set; }
        public long? DepartmentTypeId { get; set; }
        public string? DepartmentType { get; set; }
        public string? DepartmentStructure { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class DepartmentUser
    {
        public long Id { get; set; }
        public long? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public long? UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActived { get; set; }
        public long? UserRoleId { get; set; }
        public string? UserRoleName { get; set; }
        public bool? IsManager { get; set; }
        public string? DepartmentStructure { get; set; }
    }
}

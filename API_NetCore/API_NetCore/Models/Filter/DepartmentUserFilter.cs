using System;

namespace OKEA.Library.Models.Filter
{
    public class DepartmentUserFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public long? UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool? IsManager { get; set; }
        public string DepartmentStructure { get; set; }
    }
}

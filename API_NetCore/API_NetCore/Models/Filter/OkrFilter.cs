using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class OkrFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public long? DepartmentId { get; set; }
        public string Name { get; set; }
        public int? OKrPercent { get; set; }
        public string UserFullname { get; set; }
        public string Email { get; set; }
        public int? Gender { get; set; }
        public int? UserRole { get; set; }
        public string DepartmentName { get; set; }
        public string OkrType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public Status? Status { get; set; }
    }
}

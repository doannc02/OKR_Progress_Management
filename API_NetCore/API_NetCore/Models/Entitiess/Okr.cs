using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Okr
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int OkrPercent { get; set; }
        public long UserId { get; set; }
        public string? UserFullname { get; set; }
        public string? Email { get; set; }
        public int Gender { get; set; }
        public string? Password { get; set; }
        public int UserRole { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Status { get; set; }
        public bool? IsActived { get; set; }
        public long DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? OkrType { get; set; }
    }
}

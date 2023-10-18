using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class User
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
        public string? Password { get; set; }
        public int UserRole { get; set; }
        public int CurrentStar { get; set; }
        public bool IsActived { get; set; }
        public string? ActivationCode { get; set; }
        public long? RoleOfUserId { get; set; }
        public string? Role { get; set; }
        public string? DepartmentName { get; set; }
        public long? DepartmentId { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Avatar { get; set; }
        public int GivenStar { get; set; }
    }
}

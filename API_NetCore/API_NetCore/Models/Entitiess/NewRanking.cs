using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class NewRanking
    {
        public long Id { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public long? Rank { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Gender { get; set; }
        public string? Avatar { get; set; }
        public DateTime? Birthday { get; set; }
        public long? RoleOfUserId { get; set; }
        public string Role { get; set; } = null!;
        public int CurrentStar { get; set; }
        public bool IsActived { get; set; }
    }
}

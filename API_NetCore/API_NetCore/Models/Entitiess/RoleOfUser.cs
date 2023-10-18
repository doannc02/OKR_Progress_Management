using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class RoleOfUser
    {
        public long Id { get; set; }
        public string Role { get; set; } = null!;
        public long AdminId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool? IsActived { get; set; }
    }
}

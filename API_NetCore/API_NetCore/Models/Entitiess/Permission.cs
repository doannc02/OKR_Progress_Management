using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Permission
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Name { get; set; } = null!;
        public string Method { get; set; } = null!;
        public bool IsActived { get; set; }
    }
}

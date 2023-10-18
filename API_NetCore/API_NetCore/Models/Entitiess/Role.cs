using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Role
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Controller { get; set; } = null!;
        public byte? RoleType { get; set; }
        public bool IsActived { get; set; }
    }
}

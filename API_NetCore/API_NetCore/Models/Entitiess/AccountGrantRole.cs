using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class AccountGrantRole
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long PermissionId { get; set; }
        public byte? RoleType { get; set; }
        public bool IsActived { get; set; }
    }
}

using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Filter
{
    public class AccountGrantRoleFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? AccountId { get; set; }
        public long? PermissionId { get; set; }
        public RoleType? RoleType { get; set; }
    }
}

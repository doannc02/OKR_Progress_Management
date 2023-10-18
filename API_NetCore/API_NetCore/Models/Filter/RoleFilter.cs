using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Filter
{
    public class RoleFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public RoleType? RoleType { get; set; }
    }
}

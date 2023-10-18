namespace OKEA.Library.Models.Filter
{
    public class PermissionFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? RoleId { get; set; }
        public string Name { get; set; }
        public string Method { get; set; }
    }
}

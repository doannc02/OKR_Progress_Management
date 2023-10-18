namespace OKEA.Library.Models.Filter
{
    public class UserRoleFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? DepartmentTypeId { get; set; }
        public string DepartmentType { get; set; }
        public string Role { get; set; }
    }
}

namespace OKEA.Library.Models.Cache
{
    public class DepartmentUserCache
    {
        public long ?DepartmentId { get; set; }
        public long? ParentId { get; set; }
        public string DepartmentName { get; set; }
        public long? UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool ?IsManager { get; set; }
        public string DepartmentStructure { get; set; }
    }
}

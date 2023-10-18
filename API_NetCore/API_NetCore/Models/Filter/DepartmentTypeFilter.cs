namespace OKEA.Library.Models.Filter
{
    public class DepartmentTypeFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerType { get; set; }
    }
}

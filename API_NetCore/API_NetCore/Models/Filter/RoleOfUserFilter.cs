namespace OKEA.Library.Models.Filter
{
    public class RoleOfUserFilter : FilterBase
    {
        public long? Id { get; set; }
        public string Role { get; set; }
        public long? AdminId { get; set; }
    }
}

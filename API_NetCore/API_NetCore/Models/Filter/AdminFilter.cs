using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Filter
{
    /// <summary>
    /// AdminFilter
    /// </summary>
    public class AdminFilter : FilterBase
    {
        public long? Id { get; set; }
        /// <summary>
        /// Filter by LoginName
        /// </summary>
        public string LoginName { get; set; }
        public AdminRole? AdminRole { get; set; }
        /// <summary>
        /// Filter by Role
        /// </summary>
        public AdminRole? Role { get; set; }
    }
}

using System.Collections.Generic;

namespace OKEA.Library.Models.Request
{
    /// <summary>
    /// Data Add Multiple User to Department
    /// </summary>
    public class AddMultiDepartmentUser
    {
        /// <summary>
        /// DepartmentId
        /// </summary>
        public long DepartmentId { get; set; }
        /// <summary>
        /// UserIds
        /// </summary>
        public List<long> UserIds { get; set; }
    }
}

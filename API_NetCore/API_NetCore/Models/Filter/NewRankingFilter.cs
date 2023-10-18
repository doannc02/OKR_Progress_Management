using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.Filter
{
    public class NewRankingFilter : FilterBase
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// DepartmentId
        /// </summary>
        public long? DepartmentId { get; set; }
        /// <summary>
        /// DepartmentName
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// Rank
        /// </summary>
        public long? Rank { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// Birthday
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// RoleOfUserId
        /// </summary>
        public long? RoleOfUserId { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// CurrentStar
        /// </summary>
        public int? CurrentStar { get; set; }
    }
}

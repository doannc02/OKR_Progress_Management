using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Cache
{
    public class ElearningMemberCache
    {
        /// <summary>
        /// Cache UserId
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Cache Name
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Cache Gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Cache Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// UserRole
        /// </summary>
        public int UserRole { get; set; }
        /// <summary>
        /// CurrentStar
        /// </summary>
        public int CurrentStar { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// DepartmentId
        /// </summary>
        public long? DepartmentId { get; set; }
        /// <summary>
        /// DepartmentName
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// DepartmentUserJson
        /// </summary>
        public string DepartmentUserJson { get; set; }
        /// <summary>
        /// DepartmentStructure
        /// </summary>
        public string DepartmentStructure { get; set; }
        /// <summary>
        /// IsManager
        /// </summary>
        public bool IsManager { get; set; }
        /// <summary>
        /// IsWritter
        /// </summary>
        public bool IsWritter { get; set; }
        /// <summary>
        /// User avatar
        /// </summary>
        public string Avatar { get; set; }
    }
}

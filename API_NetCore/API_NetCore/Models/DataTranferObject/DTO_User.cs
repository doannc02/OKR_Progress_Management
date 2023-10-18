using OKEA.Library.Models.Enums;

namespace API_NetCore.Models.DataTranferObject
{
    public class DTO_User
    {
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
        /// Filter by FullName
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Filter by Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Avatar
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// Filter by Gender
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Filter by Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Filter by UserRole
        /// </summary>
        public int? UserRole { get; set; }
        /// <summary>
        /// Filter by CurrentStar
        /// </summary>
        public int? CurrentStar { get; set; }
        /// <summary>
        /// Filter by ActivationCode
        /// </summary>
        public string ActivationCode { get; set; }
        /// <summary>
        /// Filter by RoleOfUserId
        /// </summary>
        public long? RoleOfUserId { get; set; }
        /// <summary>
        /// Filter by Role
        /// </summary>
        public string Role { get; set; }
        public bool? IsActived { get; set; }
    }
}

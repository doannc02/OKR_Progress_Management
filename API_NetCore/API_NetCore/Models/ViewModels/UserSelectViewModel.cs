using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.ViewModels
{
    public class UserSelectViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// FullName
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// UserRole
        /// </summary>
        public int UserRole { get; set; }
        /// <summary>
        /// CurrentStar
        /// </summary>
        public int CurrentStar { get; set; }
        /// <summary>
        /// IsActived
        /// </summary>
        public bool IsActived { get; set; }
        /// <summary>
        /// ActivationCode
        /// </summary>
        public string ActivationCode { get; set; }
        /// <summary>
        /// RoleOfUserId
        /// </summary>
        public long RoleOfUserId { get; set; }
        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// IsChecked
        /// </summary>
        public bool IsChecked { get; set; }
    }
}

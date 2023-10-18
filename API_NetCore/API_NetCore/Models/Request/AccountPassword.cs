namespace OKEA.Library.Models.Request
{
    /// <summary>
    /// Use for change user (or admnin) password
    /// </summary>
    public class AccountPassword
    {
        /// <summary>
        /// Empty when use cookie
        /// </summary>
        public long? UserId { get; set; }
        /// <summary>
        /// OldPassword
        /// </summary>
        public string OldPassword { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
    }
}

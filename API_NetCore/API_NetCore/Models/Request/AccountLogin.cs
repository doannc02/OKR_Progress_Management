namespace OKEA.Library.Models.Request
{
    /// <summary>
    /// Data login of user or admin
    /// </summary>
    public class AccountLogin
    {
        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Ip address of network where user take login action
        /// </summary>
      
    }
}

namespace OKEA.Library.Models.Response
{
    /// <summary>
    /// LoginResponse
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Object response
        /// </summary>
        public object User { get; set; }
        /// <summary>
        /// Token response
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// IsManager
        /// </summary>
        public bool IsManager { get; set; }
    }
    /// <summary>
    /// LoginResponse by T object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoginResponse<T>
    {
        /// <summary>
        /// T object
        /// </summary>
        public T User { get; set; }
        /// <summary>
        /// Token string
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// IsManager
        /// </summary>
        public bool IsManager { get; set; }
    }
}

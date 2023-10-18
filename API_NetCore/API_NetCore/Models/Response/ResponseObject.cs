using System;

namespace OKEA.Library.Models.Response
{
    /// <summary>
    /// ResponseObject
    /// </summary>
    public class ResponseObject
    {
        /// <summary>
        /// ErrorCode: 0 = success, -1 = error
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }
    }
    /// <summary>
    /// ResponseObject by T object
    /// </summary>
    public class ResponseObject<T>
    {
        /// <summary>
        /// ErrorCode: 0 = success, -1 = error
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Data object T
        /// </summary>
        public T Data { get; set; }

        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}

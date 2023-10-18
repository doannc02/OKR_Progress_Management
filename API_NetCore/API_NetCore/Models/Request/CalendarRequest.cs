using System;

namespace OKEA.Library.Models.Request
{
    public class CalendarRequest
    {
        /// <summary>
        /// Id CheckInSchedule
        /// </summary>
        public long? Id { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullName { get; set; }
        public string MemberEmail { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        /// <summary>
        /// Xác định thay đổi tất cả hay chỉ 1 sự kiện checkin
        /// </summary>
        public long? StatusUpdate { get; set; }
    }
}

using OKEA.Library.Models.Enums;
using System;

namespace OKEA.Library.Models.ViewModels
{
    public class CalendarViewModel
    {
        public long? Id { get; set; }
        public long? MemberId { get; set; }
        public string MemberFullname { get; set; }
        public string MemberEmail { get; set; }
        public CheckInScheduleStatus? Status { get; set; }
        public long? ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public DateTime LastTimeCheckIn { get; set; }
        public DateTime NextTimeCheckIn { get; set; }
    }
}

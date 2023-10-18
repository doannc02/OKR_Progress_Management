namespace OKEA.Library.Models.Request
{
    public class CheckInRequest
    {
        public long? QuarterId { get; set; }
        public long? CheckInHistoryId { get; set; }
        public long? CheckInOkrId { get; set; }
        public long? OkrId { get; set; }
        public long? UserId { get; set; }
        public long? isManager { get; set; }
    }
}

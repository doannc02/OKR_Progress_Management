namespace OKEA.Library.Models.Request
{
    public class OkrFilterRequest
    {
        public long? UserId { get; set; }
        public string UserEmail { get; set; }
        public long? OkrId { get; set; }
        public bool? IsActived { get; set; }
    }
}

namespace OKEA.Library.Models.ViewModels
{
    public class MemberKeyResultActionViewModel
    {
        public long? Id { get; set; }
        public long? KeyResultId { get; set; }
        public long? UserId { get; set; }
        public string KeyResultName { get; set; }
        public string ActionName { get; set; }
        public int? ActionPercent { get; set; }
        public long QuarterId { get; set; }
        public string QuarterName { get; set; }
        public string QuarterData { get; set; }
    }
}

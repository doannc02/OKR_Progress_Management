namespace API_NetCore.Models.DataTranferObject
{
    public class DTO_KR
    {
        public long? Id { get; set; }
        public long? ObjectiveId { get; set; }
        public long? UserId { get; set; }
        public string KeyResultName { get; set; }
        public int? KeyResultPercent { get; set; }
        public long QuarterId { get; set; }
        public string QuarterName { get; set; }
        public string QuarterData { get; set; }
        public List<DTO_KrAction> KeyResultActions { get; set; }
    }
}

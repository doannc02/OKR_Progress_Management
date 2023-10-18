namespace OKEA.Library.Models.Filter
{
    public class TradingHistoryFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public long? UserId { get; set; }
        public string UserFullname { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public int? StarBefore { get; set; }
        public int? StarAfter { get; set; }
    }
}

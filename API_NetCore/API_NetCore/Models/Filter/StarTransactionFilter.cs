using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Filter
{
    public class StarTransactionFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? AdminId { get; set; }
        public long? UserId { get; set; }
        public string UserFullname { get; set; }
        public string UserEmail { get; set; }
        public string UserRole { get; set; }
        public int? TotalStarBefore { get; set; }
        public int? TotalStarAfter { get; set; }
        public TransactionType? TransactionType { get; set; }
        public int? StarChange { get; set; }
    }
}

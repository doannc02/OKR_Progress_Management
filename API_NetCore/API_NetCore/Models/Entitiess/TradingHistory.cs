using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class TradingHistory
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int ProductPrice { get; set; }
        public long UserId { get; set; }
        public string? UserFullname { get; set; }
        public string? UserEmail { get; set; }
        public string? UserRole { get; set; }
        public int StarBefore { get; set; }
        public int StarAfter { get; set; }
        public DateTime TradingTime { get; set; }
        public bool? IsActived { get; set; }
    }
}

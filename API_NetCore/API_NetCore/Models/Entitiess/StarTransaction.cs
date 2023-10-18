using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class StarTransaction
    {
        public long Id { get; set; }
        public long? AdminId { get; set; }
        public string? AdminFullname { get; set; }
        public long? UserId { get; set; }
        public string? UserFullname { get; set; }
        public string? UserEmail { get; set; }
        public string? UserRole { get; set; }
        public long? ReceiverId { get; set; }
        public string? ReceiverFullname { get; set; }
        public string? ReceiverEmail { get; set; }
        public string? ReceiverRole { get; set; }
        public int TotalStarBefore { get; set; }
        public int TotalStarAfter { get; set; }
        public int StarChange { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte TransactionType { get; set; }
        public bool? IsActived { get; set; }
        public string? Description { get; set; }
    }
}

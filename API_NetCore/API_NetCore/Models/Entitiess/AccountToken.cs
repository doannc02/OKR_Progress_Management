using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class AccountToken
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public byte Type { get; set; }
        public bool IsSuperToken { get; set; }
    }
}

using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.Filter
{
    public class AccountTokenFilter : FilterBase
    {
        public long? AccountId { get; set; }
        public string Token { get; set; }
        public TokenType? Type { get; set; }
        public bool IsSuperToken { get; set; }
    }
}

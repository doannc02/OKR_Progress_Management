using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.ViewModels
{
    public class TransactionViewModel
    {
        public long Id { get; set; }
        public string ManagerName { get; set; }
        public string MemberName { get; set; }
        public string Description { get; set; }
        public int StarChange { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

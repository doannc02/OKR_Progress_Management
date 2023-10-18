using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.ViewModels
{
    public class RankingObjectViewModel
    {
        public long Rank { get; set; }
        public long UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Role { get; set; }
        public long TotalStar { get; set; }
    }
}

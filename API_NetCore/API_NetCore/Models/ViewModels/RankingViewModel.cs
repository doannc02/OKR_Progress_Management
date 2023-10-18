using OKEA.Library.Models.Enums;

namespace OKEA.Library.Models.ViewModels
{
    public class RankingViewModel
    {
        public int Rank { get; set; }
        public long Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public long RoleOfUserId { get; set; }
        public string Role { get; set; }
        public Gender Gender { get; set; }
        public int CurrentStar { get; set; }
    }
}

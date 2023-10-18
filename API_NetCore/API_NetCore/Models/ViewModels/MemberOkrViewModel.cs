using OKEA.Library.Models.Enums;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class MemberOkrViewModel
    {
        public long? Id { get; set; }
        public string OkrName { get; set; }
        public int? OKrPercent { get; set; }
        public string OkrType { get; set; }
        public Status? OkrStatus { get; set; }
        public long? UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public string UserRoleName { get; set; }
        public long? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool AllowCheckIn { get; set; }
        public bool IsManager { get; set; }
        public string DepartmentStructure { get; set; }
        public List<MemberObjectiveViewModel> Objectives { get; set; }
    }
}

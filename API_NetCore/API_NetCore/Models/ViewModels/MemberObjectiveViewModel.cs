using OKEA.Library.Models.Enums;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class MemberObjectiveViewModel
    {
        public long? Id { get; set; }
        public long? OkrId { get; set; }
        public long? UserId { get; set; }
        public string OkrName { get; set; }
        public string ObjectiveName { get; set; }
        public int? ObjectivePercent { get; set; }
        public ObjectiveType? ObjectiveType { get; set; }
        public Status? Status { get; set; }
        public List<MemberKeyResultViewModel> KeyResults { get; set; }
    }
}

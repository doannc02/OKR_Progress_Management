
using API_NetCore.Models.Entitiess;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class CheckInViewModel
    {
        public Quarter Quarter { get; set; }
        public List<Okr> Okr { get; set; }
        public List<Objective> Objectives { get; set; }
        public List<KeyResult> KeyResults { get; set; }
        public List<KeyResultAction> KeyResultActions { get; set; }
    }
    public class CheckInDataViewModel
    {
        public List<CheckInHistory> checkInHistories { get; set; }
        public List<CheckInOkr> checkInOKRs { get; set; }
        public List<CheckInObjective> checkInObjectives { get; set; }
        public List<CheckInKeyResult> checkInKeyResults { get; set; }
    }
    public class CheckInMemberDataViewModel
    {
        public CheckInHistory checkInHistory { get; set; }
        public List<CheckInOkr> checkInOKRs { get; set; }
        public List<CheckInObjective> checkInObjectives { get; set; }
        public List<CheckInKeyResult> checkInKeyResults { get; set; }
        public List<KeyResultAction> keyResultActions { get; set; }
    }
}

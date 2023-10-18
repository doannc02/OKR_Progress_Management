using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class MemberKeyResultViewModel
    {
        public long? Id { get; set; }
        public long? ObjectiveId { get; set; }
        public long? UserId { get; set; }
        public string KeyResultName { get; set; }
        public int? KeyResultPercent { get; set; }
        public long QuarterId { get; set; }
        public string QuarterName { get; set; }
        public string QuarterData { get; set; }
        public List<MemberKeyResultActionViewModel> KeyResultActions { get; set; }
    }
}

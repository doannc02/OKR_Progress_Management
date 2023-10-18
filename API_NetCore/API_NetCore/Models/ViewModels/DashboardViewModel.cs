using API_NetCore.Models.Entitiess;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<Okr> MasterOkrs { get; set; }
        public List<SlaveOkrs> SlaveOkrs { get; set; }
    }
    public class SlaveOkrs
    {
        public List<Okr> Okrs { get; set; }
    }
}

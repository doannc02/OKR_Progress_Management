using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class DashboardChartDataViewModel
    {
        public long ManagerId { get; set; }
        public string ManagerFullName { get; set; }
        public string ManagerEmail { get; set; }
        public List<DashboardObjectiveViewModel> Objectives { get; set; }
        public List<List<int>> ObjectiveDatas { get; set; }
    }
    public class DashboardObjectiveViewModel
    {
        public long ObjectiveId { get; set; }
        public string ObjectiveName { get; set; }
        public int ObjectivePercent { get; set; }
    }
}

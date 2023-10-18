using API_NetCore.Models.Entitiess;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class ManagerOkrViewModel
    {
        public List<Objective> MasterOkrs { get; set; }
        public List<OkrQuater> OkrQuaters { get; set; }
    }
    public class OkrQuater
    {
        public string Name { get; set; }
        public List<int> Objectives { get; set; }
    }
}

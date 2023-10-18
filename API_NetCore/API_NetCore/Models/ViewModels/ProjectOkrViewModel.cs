using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class ProjectOkrViewModel
    {
        public string ProjectName { get; set; }
        public List<ObjectiveViewModel> Objectives { get; set; }
    }
    public class ObjectiveViewModel
    {
        public string Name { get; set; }
        public int Percent { get; set; }
    }
}

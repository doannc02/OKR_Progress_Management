using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class SubjectViewModel
    {
        public long Id { get; set; }
        public string SubjectName { get; set; }
        public List<LessionViewModel> Lessions { get; set; }
    }
}

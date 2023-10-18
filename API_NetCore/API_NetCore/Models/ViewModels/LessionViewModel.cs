namespace OKEA.Library.Models.ViewModels
{
    public class LessionViewModel
    {
        public long Id { get; set; }
        public string LessionTitle { get; set; }
        public string Description { get; set; }
        public string FeatureImage { get; set; }
        public long SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}

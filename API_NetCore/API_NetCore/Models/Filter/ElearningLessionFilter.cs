namespace OKEA.Library.Models.Filter
{
    public class ElearningLessionFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string LessionTitle { get; set; }
        public string Description { get; set; }
        public string FeatureImage { get; set; }
        public string LessionContent { get; set; }
    }
}

namespace OKEA.Library.Models.Filter
{
    public class ExaminationFilter : FilterBase
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// SubjectId
        /// </summary>
        public long? SubjectId { get; set; }
        /// <summary>
        /// SubjectName
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// FeatureImage
        /// </summary>
        public string FeatureImage { get; set; }
    }
}

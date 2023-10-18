namespace OKEA.Library.Models.Filter
{
    /// <summary>
    /// TutorialsFilter
    /// </summary>
    public class TutorialsFilter : FilterBase
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// Foreign key TutorialTypeId
        /// </summary>
        public long? TutorialTypeId { get; set; }
        /// <summary>
        /// TutorialType
        /// </summary>
        public string TutorialType { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// FeatureImage
        /// </summary>
        public string FeatureImage { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// AuthorId
        /// </summary>
        public long? AuthorId { get; set; }
        /// <summary>
        /// AuthorFullName
        /// </summary>
        public string AuthorFullName { get; set; }
        /// <summary>
        /// AuthorEmail
        /// </summary>
        public string AuthorEmail { get; set; }
    }
}

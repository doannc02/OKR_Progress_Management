namespace OKEA.Library.Models.Filter
{
    public class FeedbackFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? AccountId { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FeedbackNote { get; set; }
        public int? Rate { get; set; }
    }
}

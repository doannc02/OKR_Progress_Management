namespace OKEA.Library.Models.Filter
{
    public class FeedbackImageFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? FeedbackId { get; set; }
        public string Image { get; set; }
    }
}

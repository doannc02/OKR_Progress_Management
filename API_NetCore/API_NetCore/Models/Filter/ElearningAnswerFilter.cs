namespace OKEA.Library.Models.Filter
{
    public class ElearningAnswerFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? QuestionId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

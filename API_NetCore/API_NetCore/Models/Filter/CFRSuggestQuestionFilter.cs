namespace OKEA.Library.Models.Filter
{
    public class CFRSuggestQuestionFilter : FilterBase
    {
        public long? Id { get; set; }
        public string QuestionType { get; set; }
        public long? QuestionTypeId { get; set; }
        public string Question { get; set; }
    }
}

namespace OKEA.Library.Models.Filter
{
    public class ElearningQuestionFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? QuestionTypeId { get; set; }
        public string QuestionType { get; set; }
        public long? SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Question { get; set; }
    }
}

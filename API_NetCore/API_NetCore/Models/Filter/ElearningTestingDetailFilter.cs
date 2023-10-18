namespace OKEA.Library.Models.Filter
{
    public class ElearningTestingDetailFilter : FilterBase
    {
        public long? Id { get; set; }
        public long? TestingResultId { get; set; }
        public long? QuestionId { get; set; }
        public int? Score { get; set; }
    }
}

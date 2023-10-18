namespace OKEA.Library.Models.ViewModels
{
    /// <summary>
    /// ExaminationAnswerViewModel
    /// </summary>
    public class ExaminationAnswerViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// QuestionId
        /// </summary>
        public long QuestionId { get; set; }
        /// <summary>
        /// Question
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Answer
        /// </summary>
        public string Answer { get; set; }
    }
}

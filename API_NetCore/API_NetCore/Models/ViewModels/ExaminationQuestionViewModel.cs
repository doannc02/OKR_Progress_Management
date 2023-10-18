using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    /// <summary>
    /// ExaminationQuestionViewModel
    /// </summary>
    public class ExaminationQuestionViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// QuestionTypeId
        /// </summary>
        public long QuestionTypeId { get; set; }
        /// <summary>
        /// QuestionType
        /// </summary>
        public string QuestionType { get; set; }
        /// <summary>
        /// SubjectId
        /// </summary>
        public long SubjectId { get; set; }
        /// <summary>
        /// SubjectName
        /// </summary>
        public string SubjectName { get; set; }
        /// <summary>
        /// Question
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Answers
        /// </summary>
        public List<ExaminationAnswerViewModel> Answers { get; set; }
    }
}

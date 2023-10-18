using System;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    /// <summary>
    /// ExaminationViewModel
    /// </summary>
    public class ExaminationViewModel
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// SubjectId
        /// </summary>
        public long SubjectId { get; set; }
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
        /// <summary>
        /// CreatedDate
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// StartedDate
        /// </summary>
        public DateTime? StartedDate { get; set; }
        /// <summary>
        /// IsActived
        /// </summary>
        public bool IsActived { get; set; }
        /// <summary>
        /// Questions
        /// </summary>
        public List<ExaminationQuestionViewModel> Questions { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningQuestion
    {
        public long Id { get; set; }
        public long QuestionTypeId { get; set; }
        public string QuestionType { get; set; } = null!;
        public string Question { get; set; } = null!;
        public bool? IsActived { get; set; }
        public long? SubjectId { get; set; }
        public string? SubjectName { get; set; }
    }
}

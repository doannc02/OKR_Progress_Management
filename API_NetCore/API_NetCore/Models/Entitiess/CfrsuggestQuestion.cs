using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CfrsuggestQuestion
    {
        public long Id { get; set; }
        public string Question { get; set; } = null!;
        public bool IsActived { get; set; }
        public string? QuestionType { get; set; }
        public long? QuestionTypeId { get; set; }
    }
}

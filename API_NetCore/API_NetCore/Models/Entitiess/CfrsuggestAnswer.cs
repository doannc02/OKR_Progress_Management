using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CfrsuggestAnswer
    {
        public long Id { get; set; }
        public long? QuestionId { get; set; }
        public string Answer { get; set; } = null!;
        public bool IsActived { get; set; }
        public string? Question { get; set; }
    }
}

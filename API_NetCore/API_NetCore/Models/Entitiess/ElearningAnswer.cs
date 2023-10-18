using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningAnswer
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public bool? IsActived { get; set; }
    }
}

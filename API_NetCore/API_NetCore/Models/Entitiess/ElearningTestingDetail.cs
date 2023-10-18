using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningTestingDetail
    {
        public long Id { get; set; }
        public long TestingResultId { get; set; }
        public long QuestionId { get; set; }
        public int Score { get; set; }
        public bool? IsActived { get; set; }
    }
}

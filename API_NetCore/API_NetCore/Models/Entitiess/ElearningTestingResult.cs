using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningTestingResult
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserFullName { get; set; }
        public DateTime? TestingTime { get; set; }
        public int NumberOfQuestion { get; set; }
        public int TotalScore { get; set; }
        public bool? IsActived { get; set; }
    }
}

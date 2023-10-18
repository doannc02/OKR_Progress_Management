using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Objective
    {
        public long Id { get; set; }
        public long OkrId { get; set; }
        public string? OkrName { get; set; }
        public long UserId { get; set; }
        public string? UserFullname { get; set; }
        public string ObjectiveName { get; set; } = null!;
        public int ObjectivePercent { get; set; }
        public byte ObjectiveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Status { get; set; }
        public bool? IsActived { get; set; }
    }
}

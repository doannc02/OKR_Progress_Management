using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningLession
    {
        public long Id { get; set; }
        public long SubjectId { get; set; }
        public string SubjectName { get; set; } = null!;
        public string LessionTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string? FeatureImage { get; set; }
        public string? LessionContent { get; set; }
        public bool? IsActived { get; set; }
    }
}

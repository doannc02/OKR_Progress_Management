using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ElearningSubject
    {
        public long Id { get; set; }
        public string SubjectName { get; set; } = null!;
        public string? Description { get; set; }
        public bool? IsActived { get; set; }
    }
}

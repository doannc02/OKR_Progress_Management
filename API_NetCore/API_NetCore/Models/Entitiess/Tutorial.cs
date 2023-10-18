using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Tutorial
    {
        public long Id { get; set; }
        public long TutorialTypeId { get; set; }
        public string TutorialType { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? FeatureImage { get; set; }
        public string Content { get; set; } = null!;
        public bool IsActived { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? AuthorId { get; set; }
        public string? AuthorFullName { get; set; }
        public string? AuthorEmail { get; set; }
    }
}

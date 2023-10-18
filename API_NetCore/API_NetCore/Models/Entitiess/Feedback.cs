using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Feedback
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public byte Rate { get; set; }
        public bool IsActived { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Fullname { get; set; }
        public string? FeedbackNote { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class FeedbackImage
    {
        public long Id { get; set; }
        public long FeedbackId { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

using API_NetCore.Models.Entitiess;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class FeedbackViewModel
    {
        public Feedback Data { get; set; }
        public List<FeedbackImage> Images { get; set; }
    }
}

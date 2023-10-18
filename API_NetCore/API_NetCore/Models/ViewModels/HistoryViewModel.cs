using OKEA.Library.Models.Enums;
using System;
using System.Collections.Generic;

namespace OKEA.Library.Models.ViewModels
{
    public class HistoryViewModel
    {
        public List<CheckInHistoryView> Data { get; set; }
        public long PaginationCount { get; set; }
    }

    public class CheckInHistoryView
    {
        public long Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int Star { get; set; }
        public string CFRSuggestComment { get; set; }
        public string CFRCommentManager { get; set; }
        public string Comment { get; set; }
        public CheckInHistoryType Status { get; set; }
    }
}

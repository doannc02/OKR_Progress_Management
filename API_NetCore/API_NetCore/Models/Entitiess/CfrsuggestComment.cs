using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class CfrsuggestComment
    {
        public long Id { get; set; }
        public string Comment { get; set; } = null!;
        public bool IsActived { get; set; }
        public int Star { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ManagerSchedule
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Gender { get; set; }
    }
}

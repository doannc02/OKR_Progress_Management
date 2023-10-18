using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class ScriptManagement
    {
        public long Id { get; set; }
        public string SqlScriptFile { get; set; } = null!;
        public DateTime ExecuteTime { get; set; }
        public bool? IsActived { get; set; }
    }
}

using System;

namespace OKEA.Library.Models.Filter
{
    public class ScriptManagementFilter : FilterBase
    {
        public long? Id { get; set; }
        public string SqlScriptFile { get; set; }
        public DateTime? ExecuteTime { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace API_NetCore.Models.Entitiess
{
    public partial class Admin
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LoginName { get; set; } = null!;
        public string? Password { get; set; }
        public int AdminRole { get; set; }
        public bool IsActived { get; set; }
    }
}

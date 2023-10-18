using API_NetCore.Models.Entitiess;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKEA.Library.Models.ViewModels
{
    public class DepartmentForUserViewModel : Department
    {
        public bool IsManager { get; set; }
    }
}

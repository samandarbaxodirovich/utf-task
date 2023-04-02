using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Common;

namespace utf_task.Service.ViewModels
{
    public class EmployeeViewModel:Auditable
    {
        public string FullName { get; set; }=String.Empty;

        public string PhoneNumber { get; set; }=String.Empty;

    }
}

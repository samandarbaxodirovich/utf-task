using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.Domain.Entities;

namespace utf_task.Service.Dtos.UpdateDtos
{
    public class EmployeeUpdateDto
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }

    }
}

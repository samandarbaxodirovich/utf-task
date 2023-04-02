using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.Interfaces.Common;
using utf_task.Domain.Entities;

namespace utf_task.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
    }
}

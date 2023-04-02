using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.DbContexts;
using utf_task.DataAccess.Interfaces;
using utf_task.DataAccess.Repositories.Common;
using utf_task.Domain.Entities;

namespace utf_task.DataAccess.Repositories
{
    public class EmployeeRepository:GenericRepository<Employee>,
        IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext) :base(appDbContext)
        {
        }
    }
}

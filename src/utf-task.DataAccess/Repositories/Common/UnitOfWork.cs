using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.DbContexts;
using utf_task.DataAccess.Interfaces;
using utf_task.DataAccess.Interfaces.Common;

namespace utf_task.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IAdminRepository Admins { get; }
        public IEmployeeRepository Employees { get; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;

            Admins = new AdminRepository(appDbContext);
            Employees = new EmployeeRepository(appDbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}

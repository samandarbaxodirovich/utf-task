using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.DbContexts;
using utf_task.DataAccess.Interfaces;
using utf_task.DataAccess.Repositories.Common;
using utf_task.Domain.Entities;

namespace utf_task.DataAccess.Repositories
{
    public class AdminRepository : GenericRepository<Admin>,
        IAdminRepository
    {
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

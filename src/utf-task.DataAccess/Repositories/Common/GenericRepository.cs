using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using utf_task.DataAccess.DbContexts;
using utf_task.DataAccess.Interfaces.Common;
using utf_task.Domain.Common;

namespace utf_task.DataAccess.Repositories.Common
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
        public virtual IQueryable<T> GetAll() => _dbSet;

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);
    }
}

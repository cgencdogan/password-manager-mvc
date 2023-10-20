using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract;
public interface IBaseRepository<T>
    where T : class, IEntity {
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> expression = null);
}

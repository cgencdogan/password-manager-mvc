using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.Repositories;
public interface ISavedPasswordRepository : IBaseRepository<SavedPassword> {
    Task<SavedPassword> GetIncludeUserAsync(Expression<Func<SavedPassword, bool>> expression);
}

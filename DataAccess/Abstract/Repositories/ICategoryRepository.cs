using Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract.Repositories;

public interface ICategoryRepository : IBaseRepository<Category> {
    Task<Category> GetIncludeUserAndSavedPasswordsAsync(Expression<Func<Category, bool>> expression);
}
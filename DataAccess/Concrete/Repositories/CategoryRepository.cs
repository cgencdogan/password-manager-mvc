using DataAccess.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.Repositories;

public class CategoryRepository : EFBaseRepository<Category>, ICategoryRepository {
    public CategoryRepository(MsDbContext context) : base(context) { }

    public async Task<Category> GetIncludeUserAndSavedPasswordsAsync(Expression<Func<Category, bool>> expression) {
        return await Context.Set<Category>().AsNoTracking()
            .Include(sp => sp.User).AsNoTracking()
            .Include(sp => sp.SavedPasswords).AsNoTracking()
            .SingleOrDefaultAsync(expression);
    }
}
using DataAccess.Abstract;
using DataAccess.Abstract.Repositories;
using DataAccess.Concrete.Contexts;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Repositories;
public class SavedPasswordRepository : EFBaseRepository<SavedPassword>, ISavedPasswordRepository {
    public SavedPasswordRepository(MsDbContext context) : base(context) { }

    public async Task<SavedPassword> GetIncludeUserAsync(Expression<Func<SavedPassword, bool>> expression) {
        return await Context.Set<SavedPassword>().AsNoTracking().Include(sp=> sp.User).AsNoTracking().SingleOrDefaultAsync(expression);
    }
}
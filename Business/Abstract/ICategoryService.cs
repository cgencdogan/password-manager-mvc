using Common.Results;
using Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;
public interface ICategoryService {
    Task<IDataResult<List<CategoryDto>>> GetAllByUserIdAsync(string userId);
    Task<IDataResult<CategoryDto>> AddAsync(string categoryName, string userId);
    Task<IResult> DeleteAsync(Guid categoryId, string userId);
}

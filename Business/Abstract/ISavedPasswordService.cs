using Common.DataTransferObjects;
using Common.Results;

namespace Business.Abstract;

public interface ISavedPasswordService {
    Task<IDataResult<List<SavedPasswordDto>>> GetAllByUserIdAsync(string userId);
    Task<IDataResult<SavedPasswordDto>> UpdateAsync(SavedPasswordDto savedPasswordDto, string userId);
    Task<IDataResult<SavedPasswordDto>> AddAsync(SavedPasswordDto savedPasswordDto);
    Task<IResult> DeleteAsync(Guid savedPasswordId, string userId);
}

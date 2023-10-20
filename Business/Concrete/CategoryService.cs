using AutoMapper;
using Business.Abstract;
using Common.DataTransferObjects;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using Common.Results;

namespace Business.Concrete;
public class CategoryService : ICategoryService {
    private ICategoryRepository _categoryRepository;
    private ISavedPasswordRepository _savedPasswordRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, ISavedPasswordRepository savedPasswordRepository) {
        _categoryRepository = categoryRepository;
        _savedPasswordRepository = savedPasswordRepository;
        _mapper = mapper;
    }

    public async Task<IDataResult<CategoryDto>> AddAsync(string categoryName, string userId) {
        var category = new CategoryDto() {
            Id = Guid.NewGuid(),
            Name = categoryName,
            UserId = userId
        };

        try {
            var addedCategory = await _categoryRepository.AddAsync(_mapper.Map<Category>(category));
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(addedCategory), "Kategori oluşturuldu");
        }
        catch (Exception) {
            return new DataResult<CategoryDto>(null, false, "Kategori oluşturulamadı");
        }
    }

    public async Task<IResult> DeleteAsync(Guid categoryId, string userId) {
        var category = await _categoryRepository.GetIncludeUserAndSavedPasswordsAsync(a => a.Id == categoryId);

        if (category.User.Id == userId) {
            var savedPasswords = await _savedPasswordRepository.GetListAsync(a => a.CategoryId == categoryId);
            foreach (var savedPassword in savedPasswords) {
                savedPassword.CategoryId = null;
            }

            try {
                await _categoryRepository.DeleteAsync(category);
                return new SuccessResult("Kategori silindi");
            }
            catch (Exception) {
                return new Result(false, "Kategori silinemedi");
            }
        }

        return new Result(false, "Kullanıcı bilgileri hatalı");
    }

    public async Task<IDataResult<List<CategoryDto>>> GetAllByUserIdAsync(string userId) {
        try {
            var categories = (await _categoryRepository.GetListAsync(a => a.User.Id == userId)).ToList();
            return new SuccessDataResult<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(categories), "Kullanıcıya ait kategoriler getirildi.");
        }
        catch (Exception) {
            return new DataResult<List<CategoryDto>>(null, false, "Kullanıcıya ait kategoriler getirilemedi");
        }
    }
}
using AutoMapper;
using Business.Abstract;
using Common.DataTransferObjects;
using DataAccess.Abstract.Repositories;
using Entities.Concrete;
using Common.Results;

namespace Business.Concrete;

public class SavedPasswordService : ISavedPasswordService {
    private ISavedPasswordRepository _savedPasswordRepository;
    private IEncryption _encryption;
    private readonly IMapper _mapper;

    public SavedPasswordService(ISavedPasswordRepository savedPasswordRepository, IMapper mapper, IEncryption encryption) {
        _savedPasswordRepository = savedPasswordRepository;
        _encryption = encryption;
        _mapper = mapper;
    }

    public async Task<IDataResult<SavedPasswordDto>> AddAsync(SavedPasswordDto savedPasswordDto) {
        var savedPasswordToAdd = _mapper.Map<SavedPassword>(savedPasswordDto);

        savedPasswordToAdd.Id = Guid.NewGuid();

        //Veri tabanının kötü amaçlı kişilerin eline geçme ihtimaline karşın kullanıcı adı ve şifreyi encryptliyoruz
        savedPasswordToAdd.Password = _encryption.EncryptString(savedPasswordToAdd.Password);
        savedPasswordToAdd.UserName = _encryption.EncryptString(savedPasswordToAdd.UserName);

        if (savedPasswordToAdd.CategoryId == Guid.Empty) {
            savedPasswordToAdd.CategoryId = null;
        }

        var addedSavedPassword = await _savedPasswordRepository.AddAsync(savedPasswordToAdd);
        return new SuccessDataResult<SavedPasswordDto>(_mapper.Map<SavedPasswordDto>(addedSavedPassword), "Şifre kaydedildi");
    }

    public async Task<IResult> DeleteAsync(Guid savedPasswordId, string userId) {
        var savedPassword = await _savedPasswordRepository.GetIncludeUserAsync(a => a.Id == savedPasswordId);

        if (savedPassword.User.Id == userId) {
            await _savedPasswordRepository.DeleteAsync(savedPassword);
            return new SuccessResult("Şifre silindi");
        }

        return new Result(false, "Şifre silinemedi");
    }

    public async Task<IDataResult<List<SavedPasswordDto>>> GetAllByUserIdAsync(string userId) {
        var savedPasswords = (await _savedPasswordRepository.GetListAsync(a => a.User.Id == userId)).ToList();

        //Veri tabanından kriptolu gelen kullanıcı adı ve şifreyi UI'ya göndermeden önce decrypt ediyoruz
        foreach (var savedPassword in savedPasswords) {
            savedPassword.Password = _encryption.DecryptString(savedPassword.Password);
            savedPassword.UserName = _encryption.DecryptString(savedPassword.UserName);
        }

        return new SuccessDataResult<List<SavedPasswordDto>>(_mapper.Map<List<SavedPasswordDto>>(savedPasswords), "Kullanıcıya ait şifreler getirildi");
    }

    public async Task<IDataResult<SavedPasswordDto>> UpdateAsync(SavedPasswordDto savedPasswordDto, string userId) {
        var savedPassword = await _savedPasswordRepository.GetIncludeUserAsync(a => a.Id == savedPasswordDto.Id);
        if (savedPassword.UserId == userId) {
            savedPasswordDto.UserId = userId;
            savedPasswordDto.Password = _encryption.EncryptString(savedPasswordDto.Password);
            savedPasswordDto.UserName = _encryption.EncryptString(savedPasswordDto.UserName);
            if (savedPasswordDto.CategoryId == Guid.Empty) {
                savedPasswordDto.CategoryId = null;
            }
            var updatedSavedPassword = await _savedPasswordRepository.UpdateAsync(_mapper.Map<SavedPassword>(savedPasswordDto));
            return new SuccessDataResult<SavedPasswordDto>(_mapper.Map<SavedPasswordDto>(updatedSavedPassword), "Kayıtlı şifre güncellendi");
        }

        return new DataResult<SavedPasswordDto>(null, false, "Kayıtlı şifre güncellenemedi");
    }
}
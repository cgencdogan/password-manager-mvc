using Microsoft.AspNetCore.Identity;

namespace PasswordManager.Utility;

public class TrLocalizedIdentityErrorDescriber : IdentityErrorDescriber {
    public override IdentityError DefaultError() {
        return new IdentityError {
            Code = nameof(DefaultError),
            Description = $"Bilinmeyen bir hata meydana geldi."
        };
    }
    public override IdentityError ConcurrencyFailure() {
        return new IdentityError {
            Code = nameof(ConcurrencyFailure),
            Description = "Optimistic concurrency failure, object has been modified."
        };
    }
    public override IdentityError PasswordMismatch() {
        return new IdentityError {
            Code = nameof(PasswordMismatch),
            Description = "Şifreler uyuşmuyor."
        };
    }
    public override IdentityError InvalidToken() {
        return new IdentityError {
            Code = nameof(InvalidToken),
            Description = "Geçersiz token."
        };
    }
    public override IdentityError LoginAlreadyAssociated() {
        return new IdentityError {
            Code = nameof(LoginAlreadyAssociated),
            Description = "Bu bilgileri kullanan bir kullanıcı mevcut."
        };
    }
    public override IdentityError InvalidUserName(string userName) {
        return new IdentityError {
            Code = nameof(InvalidUserName),
            Description = $"{userName}' geçersiz, kullanıcı adı sadece harf ve rakam içerebilir."
        };
    }
    public override IdentityError InvalidEmail(string email) {
        return new IdentityError {
            Code = nameof(InvalidEmail),
            Description = $"'{email}' adresi geçersiz."
        };
    }
    public override IdentityError DuplicateUserName(string userName) {
        return new IdentityError {
            Code = nameof(DuplicateUserName),
            Description = $"'{userName}' kullanıcı adı zaten kullanılıyor."
        };
    }
    public override IdentityError DuplicateEmail(string email) {
        return new IdentityError {
            Code = nameof(DuplicateEmail),
            Description = $"'{email}' adresi zaten kullanılıyor.."
        };
    }
    public override IdentityError InvalidRoleName(string role) {
        return new IdentityError {
            Code = nameof(InvalidRoleName),
            Description = $"'{role}' rolü geçersiz."
        };
    }
    public override IdentityError DuplicateRoleName(string role) {
        return new IdentityError {
            Code = nameof(DuplicateRoleName),
            Description = $"'{role}' adlı rol zaten var."
        };
    }
    public override IdentityError UserAlreadyHasPassword() {
        return new IdentityError {
            Code = nameof(UserAlreadyHasPassword),
            Description = "Kullanıcının şifresi kaydedilmiş."
        };
    }
    public override IdentityError UserLockoutNotEnabled() {
        return new IdentityError {
            Code = nameof(UserLockoutNotEnabled),
            Description = "Bu kullanıcı için kilitleme aktif değil"
        };
    }
    public override IdentityError UserAlreadyInRole(string role) {
        return new IdentityError {
            Code = nameof(UserAlreadyInRole),
            Description = $"Kullanıcı zaten '{role}' rolüne sahip."
        };
    }
    public override IdentityError UserNotInRole(string role) {
        return new IdentityError {
            Code = nameof(UserNotInRole),
            Description = $"Kullanıcı '{role}' rolüne sahip değil."
        };
    }
    public override IdentityError PasswordTooShort(int length) {
        return new IdentityError {
            Code = nameof(PasswordTooShort),
            Description = $"Şifre en az {length} karakter olmalıdır."
        };
    }
    public override IdentityError PasswordRequiresNonAlphanumeric() {
        return new IdentityError {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "Şifre en az bir tane alfanümerik karakter içermelidir."
        };
    }
    public override IdentityError PasswordRequiresDigit() {
        return new IdentityError {
            Code = nameof(PasswordRequiresDigit),
            Description = "Şifre en az bir tane rakam içermelidir ('0'-'9')."
        };
    }
    public override IdentityError PasswordRequiresLower() {
        return new IdentityError {
            Code = nameof(PasswordRequiresLower),
            Description = "Şifre en az bir tane küçük harf içermelidir ('a'-'z')."
        };
    }
    public override IdentityError PasswordRequiresUpper() {
        return new IdentityError {
            Code = nameof(PasswordRequiresUpper),
            Description = "Şifre en az bir tane büyük harf içermelidir ('A'-'Z')."
        };
    }
}
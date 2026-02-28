using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçemez!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçemez!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçemez!");
            RuleFor(x => x.Username).MinimumLength(5).MaximumLength(20).WithMessage("Kullanıcı adı 5 ile 20 karakter arasında olmalıdır!");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Şifreler eşleşmiyor!");

        }
    }
}

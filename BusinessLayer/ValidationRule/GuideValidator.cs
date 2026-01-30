using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class GuideValidator :AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rehber Adı Adı Boş Geçilemez")
                .MaximumLength(30).WithMessage("30 karakterden daha kısa bir isim girin");
            RuleFor(x => x.Descrption).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Rehber Resmi Boş Geçilemez");

        }
    }
}

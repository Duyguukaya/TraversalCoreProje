using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Duyuru içerik alanı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapınız");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("En az 5 karakter veri girişi yapınız");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("En fazla 500 karakter veri girişi yapınız");
        }
    }
}

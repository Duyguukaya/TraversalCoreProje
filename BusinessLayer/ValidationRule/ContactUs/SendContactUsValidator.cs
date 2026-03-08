using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRule.ContactUs
{
    public class SendContactUsValidator: AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez").MinimumLength(5).WithMessage("Konu alanı en az 5 karakter olmalıdır").MaximumLength(100).WithMessage("Konu alanı en fazla 100 karakter olmalıdır");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj içeriği alanı boş geçilemez");
        }
    }
}

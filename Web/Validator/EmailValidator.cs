using Base.Dto;
using FluentValidation;

namespace Web.Validator
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Recipient email address must be entered");
            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Email title must be entered");
        }
    }
}

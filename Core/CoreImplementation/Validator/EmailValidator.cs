using Base.Dto;
using FluentValidation;

namespace CoreImplementation.Validator
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(x => x.To)
                .NotEmpty().WithMessage("Recipient email address must be entered");
        }
    }
}

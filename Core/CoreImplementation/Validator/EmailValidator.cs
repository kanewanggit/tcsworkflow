using Base.Dto;
using FluentValidation;

namespace CoreImplementation.Validator
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(x => x.From)
                .NotNull().NotEmpty().WithMessage("From must be entered");
        }
    }
}

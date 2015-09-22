using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Base.Dto;
using FluentValidation;

namespace MbWeb.Validator
{
    public class EmailValidator : AbstractValidator<EmailDto>
    {
        public EmailValidator()
        {
            RuleFor(x => x.From)
                .NotNull().NotEmpty().WithMessage("From must be entered");
            RuleFor(x => x.Subject)
                .NotNull().NotEmpty().WithMessage("Subject must be entered");
        }
    }
}
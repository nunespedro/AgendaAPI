using AgendaAPI.Domain.Model;
using FluentValidation;
using FluentValidation.Validators;

namespace AgendaAPI.Application.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required.");
            RuleFor(x => x.Phone).NotEmpty().When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage("Phone number is required if provided.");
        }
    }
}

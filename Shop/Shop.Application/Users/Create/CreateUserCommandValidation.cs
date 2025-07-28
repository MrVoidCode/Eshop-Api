using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Create;

internal class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidation()
    {
        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
            .ValidPhoneNumber();
        RuleFor(f => f.Password)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .MinimumLength(4);
        RuleFor(f => f.Email)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("ایمیل"))
            .EmailAddress().WithMessage("ایمیل نامعتبر است");
    }
}
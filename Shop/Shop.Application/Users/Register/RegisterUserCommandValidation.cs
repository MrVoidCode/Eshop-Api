using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.Register;

internal class RegisterUserCommandValidation : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidation()
    {
        RuleFor(f => f.Password)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("کلمه عبور"))
            .MinimumLength(4).WithMessage("کلمه عبور حداقل باید از 4 کلمه تشکیل شده باشد");
        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
            .MinimumLength(11)
            .MaximumLength(11);

    }
}
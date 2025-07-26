using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.AddAddress;

internal class AddAddressUserCommandValidation : AbstractValidator<AddAddressUserCommand>
{
    public AddAddressUserCommandValidation()
    {
        RuleFor(f => f.Shire)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("استان"));
        RuleFor(f => f.City)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("شهر"));
        RuleFor(f => f.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام"));
        RuleFor(f => f.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("نام خانوادگی"));
        RuleFor(f => f.PostalAddress)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("آدرس پستی"));
        RuleFor(f => f.PostalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("کد پستی"));
        RuleFor(f => f.NationalCode)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("کد ملی"))
            .MaximumLength(10).WithMessage("کد ملی نامعتبر است")
            .MinimumLength(10).WithMessage("کد ملی نامعتبر است")
            .ValidNationalId();
    }
}
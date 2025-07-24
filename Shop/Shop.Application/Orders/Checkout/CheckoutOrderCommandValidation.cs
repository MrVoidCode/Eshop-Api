using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Orders.Checkout;

internal class CheckoutOrderCommandValidation : AbstractValidator<CheckoutOrderCommand>
{
    public CheckoutOrderCommandValidation()
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
        RuleFor(f => f.PhoneNumber)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"))
            .MaximumLength(11).WithMessage("شماره تلفن نامعتبر است")
            .MinimumLength(11).WithMessage("شماره تلفن نامعتبر است");
            
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
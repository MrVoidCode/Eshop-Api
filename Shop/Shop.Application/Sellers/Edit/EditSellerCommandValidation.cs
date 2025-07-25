using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Edit;

internal class EditSellerCommandValidation : AbstractValidator<EditSellerCommand>
{
    public EditSellerCommandValidation()
    {
        RuleFor(f => f.ShopName)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("اسم فروشگاه"));
        RuleFor(f => f.NationalCode)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("کد ملی"))
            .ValidNationalId();
    }
}
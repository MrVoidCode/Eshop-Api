using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Sellers.AddInventory;

internal class AddInventorySellerCommandValidation : AbstractValidator<AddInventorySellerCommand>
{
    public AddInventorySellerCommandValidation()
    {
        RuleFor(f => f.Count)
            .NotNull().WithMessage(ValidationMessages.required("تعداد"))
            .GreaterThanOrEqualTo(1);
        RuleFor(f => f.Price)
            .NotNull().WithMessage(ValidationMessages.required("قیمت"))
            .GreaterThanOrEqualTo(1);
    }
}
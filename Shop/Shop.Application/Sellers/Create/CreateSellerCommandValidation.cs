using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Create;

internal class CreateSellerCommandValidation : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidation()
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
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Sellers.ChangeStatus;

internal class ChangeStatusSellerCommandValidation : AbstractValidator<ChangeStatusSellerCommand>
{
    public ChangeStatusSellerCommandValidation()
    {
        RuleFor(f => f.Status)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("اسم فروشگاه"));
    }
}
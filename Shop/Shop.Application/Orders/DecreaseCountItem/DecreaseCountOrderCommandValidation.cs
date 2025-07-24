using FluentValidation;

namespace Shop.Application.Orders.DecreaseCount;

internal class DecreaseCountOrderCommandValidation : AbstractValidator<DecreaseCountOrderCommand>
{
    public DecreaseCountOrderCommandValidation()
    {
        RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}
using FluentValidation;

namespace Shop.Application.Orders.IncreaseCountItem;

internal class IncreaseCountItemOrderCommandValidation : AbstractValidator<IncreaseCountItemOrderCommand>
{
    public IncreaseCountItemOrderCommandValidation()
    {
        RuleFor(f => f.Count)
            .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
    }
}
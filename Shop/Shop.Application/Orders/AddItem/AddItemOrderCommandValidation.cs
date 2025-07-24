using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Orders.AddItem;

public class AddItemOrderCommandValidation : AbstractValidator<AddItemOrderCommand>
{
    public AddItemOrderCommandValidation()
    {
        RuleFor(c => c.Count)
            .GreaterThanOrEqualTo(1)
            .WithMessage("نعداد باید بیشتر از 0 باشد");
    }
}
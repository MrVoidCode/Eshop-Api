using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage;

internal class AddImageProductCommandValidation : AbstractValidator<AddImageProductCommand>
{
    public AddImageProductCommandValidation()
    {
        RuleFor(f => f.Sequence)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .WithMessage(ValidationMessages.required("توالی"));
        RuleFor(f => f.ImageName)
            .NotNull()
            .JustImageFile();
    }
}
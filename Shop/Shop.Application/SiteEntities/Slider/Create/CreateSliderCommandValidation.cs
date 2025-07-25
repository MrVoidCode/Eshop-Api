using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Slider.Create;

internal class CreateSliderCommandValidation :AbstractValidator<CreateSliderCommand>
{
    public CreateSliderCommandValidation()
    {
        RuleFor(f => f.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();
        RuleFor(f => f.Link)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("لینک"));
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}
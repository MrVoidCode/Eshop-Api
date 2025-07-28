using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Banner.Create;

internal class CreateBannerCommandValidation : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerCommandValidation()
    {
        RuleFor(f => f.ImageFile)
            .NotNull().WithMessage(ValidationMessages.required("عکس"))
            .JustImageFile();
        RuleFor(f => f.Link)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("لینک"));
        RuleFor(f => f.Position)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("موقعیت"));
    }
}
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Edit;

internal class EditProductCommandValidation : AbstractValidator<EditProductCommand>
{
    public EditProductCommandValidation()
    {
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
        RuleFor(f => f.ImageFile)
            .JustImageFile();
        RuleFor(f => f.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("توضیحات"));
        RuleFor(f => f.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("قیمت"));
        RuleFor(f => f.Slug)
            .NotNull()
            .NotEmpty().WithMessage(ValidationMessages.required("slug"));
    }
}
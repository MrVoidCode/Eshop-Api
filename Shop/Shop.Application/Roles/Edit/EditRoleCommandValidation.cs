using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Edit;

internal class EditRoleCommandValidation : AbstractValidator<EditRoleCommand>
{
    public EditRoleCommandValidation()
    {
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}
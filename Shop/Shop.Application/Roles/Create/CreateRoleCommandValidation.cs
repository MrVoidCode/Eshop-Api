using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create;

internal class CreateRoleCommandValidation : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidation()
    {
        RuleFor(f => f.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage(ValidationMessages.required("عنوان"));
    }
}
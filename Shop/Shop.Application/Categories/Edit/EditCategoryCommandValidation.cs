using Common.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.Categories.Edit
{
    internal class EditCategoryCommandValidation : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidation()
        {
            RuleFor(c => c.Title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.Slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));

        }
    }
}

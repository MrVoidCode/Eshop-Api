using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.Create
{
    internal class CreateCategoryCommandValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidation()
        {
            RuleFor(c => c.Title)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.Slug)
                .NotEmpty().NotNull().WithMessage(ValidationMessages.required("Slug"));

        }
    }
}

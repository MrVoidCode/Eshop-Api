using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Categories.AddChild
{
    internal class AddChildCategoryCommandValidation : AbstractValidator<AddChildCategoryCommand>
    {
        public AddChildCategoryCommandValidation()
        {
            RuleFor(c => c.Title)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.Slug)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}

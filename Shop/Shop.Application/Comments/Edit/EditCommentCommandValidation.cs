using Common.Application.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Shop.Application.Comments.Edit
{
    internal class EditCommentCommandValidation : AbstractValidator<EditCommentCommand>
    {
        public EditCommentCommandValidation()
        {
            RuleFor(f => f.Text)
                .NotNull().NotEmpty().WithMessage(ValidationMessages.required("متن"));
        }
    }
}

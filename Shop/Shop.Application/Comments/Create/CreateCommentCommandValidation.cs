using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Comments.Create
{
    internal class CreateCommentCommandValidation : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidation()
        {
            RuleFor(f => f.Text)
                .MinimumLength(5).WithMessage(ValidationMessages.minLength("متن نظر", 5));
        }
    }
}

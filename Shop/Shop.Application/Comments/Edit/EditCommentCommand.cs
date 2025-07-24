using Common.Application;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    internal record EditCommentCommand(long CommentId, string Text, long UserId) : IBaseCommand
    {
    }
}

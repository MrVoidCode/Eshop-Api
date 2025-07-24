using Common.Application;
using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Create
{
    internal record CreateCommentCommand(long UserId, long ProductId, string Text) : IBaseCommand
    {
    }
}

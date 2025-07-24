using Shop.Domain.CommentAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.Comments.ChangeStatus
{
    internal record ChangeStatusCommentCommand(long CommentId, CommentStatus Status) : IBaseCommand
    {
    }
}
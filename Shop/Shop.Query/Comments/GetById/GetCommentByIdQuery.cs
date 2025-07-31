using Shop.Query.Comments.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace Shop.Query.Comments.GetById
{
    public record GetCommentByIdQuery(long CommentId) : IBaseQuery<CommentDto?>;
}

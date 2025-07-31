using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter
{
    internal class GetCommentByFilterQuery : QueryFilter<CommentFilterResult, CommentFilterParams>
    {
        public GetCommentByFilterQuery(CommentFilterParams filterParams) : base(filterParams)
        {
        }
    }
}

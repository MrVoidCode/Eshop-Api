using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CommentAgg;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.Profile
{
    internal class CommentProfiles : AutoMapper.Profile
    {
        public CommentProfiles()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}

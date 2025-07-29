using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById
{
    internal class GetCategoryByIdQuery : IBaseQuery<CategoryDto>
    {
        public long CategoryId { get; set; }

        public GetCategoryByIdQuery(long categoryId)
        {
            CategoryId = categoryId;
        }
    }
}

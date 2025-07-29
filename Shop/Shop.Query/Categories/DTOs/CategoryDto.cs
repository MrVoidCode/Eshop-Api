using Shop.Domain.CategoryAgg;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Query;

namespace Shop.Query.Categories.DTOs
{
    internal class CategoryDto : BaseDto
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ProductId { get; private set; }
        public List<Category> Child { get; private set; }
    }
}

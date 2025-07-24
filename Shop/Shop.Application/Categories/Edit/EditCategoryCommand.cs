using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Categories.Edit
{
    internal class EditCategoryCommand : IBaseCommand
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        public EditCategoryCommand(long id, string title, string slug, SeoData seoData)
        {
            Id = id;
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
    }
}

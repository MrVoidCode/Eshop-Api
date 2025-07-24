using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Categories.Create
{
    internal class CreateCategoryCommand : IBaseCommand
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }

        public CreateCategoryCommand(string title, string slug, SeoData seoData)
        {
            Title = title;
            Slug = slug;
            SeoData = seoData;
        }
    }
}

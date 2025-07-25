using Common.Application;
using Shop.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common.Application.Validation.FluentValidations;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.Create
{
    internal class CreateProductCommand : IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageName, string description, long categoryId,
            long subCategoryId, long secondCategoryId, int price, string slug, SeoData seoData, Dictionary<string, string> specifications)
        {
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondCategoryId = secondCategoryId;
            Price = price;
            Slug = slug;
            SeoData = seoData;
            Specifications = specifications;
        }
        public string Title { get; private set; }
        public IFormFile ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondCategoryId { get; private set; }
        public int Price { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public Dictionary<string, string> Specifications { get; private set; }
    }
}

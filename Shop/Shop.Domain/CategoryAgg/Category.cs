using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public long? ProductId { get; private set; }
        public List<Category> Child { get; private set; }

        public Category(string title, string slug, SeoData seoData, IDomainCategoryService domainCategoryService)
        {
            Guard(title, slug, domainCategoryService);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void Guard(string title, string slug, IDomainCategoryService domainCategoryService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug != Slug)
            {
                if (domainCategoryService.IsSlugExist(slug))
                {
                    throw new SlugIsDuplicateException("Slug تکراری است");
                }
            }
        }

        public void Edit(string title, string slug, SeoData seoData, IDomainCategoryService domainCategoryService)
        {
            Guard(title, slug, domainCategoryService);
            Title = title;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void AddChild(string title, string slug, SeoData seoData, IDomainCategoryService domainCategoryService)
        {

            Child.Add(new Category(title, slug,seoData, domainCategoryService)
            {
                ProductId = Id
            });
        }
    }
}

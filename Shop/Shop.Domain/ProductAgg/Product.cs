using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long SecondCategoryId { get; private set; }
        public int Price { get; private set; }
        public string Slug { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }
        public Product(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondCategoryId, int price, string slug, SeoData seoData, IDomainProductService domainProductService)
        {
            guard(title, imageName, description, categoryId, subCategoryId, secondCategoryId, price, slug, seoData, domainProductService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondCategoryId = secondCategoryId;
            Price = price;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void guard(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondCategoryId, int price, string slug, SeoData seoData, IDomainProductService domainProductService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug != Slug)
            {
                if (domainProductService.SlugIsExist(slug.ToSlug()))
                {
                    throw new SlugIsDuplicateException("Slug وارد شده تکراری است");
                }
            }
            if (price < 0)
            {
                throw new InvalidDomainDataException();
            }
        }

        public void Edit(string title, string imageName, string description, long categoryId,
            long subCategoryId, long secondCategoryId, int price, string slug, SeoData seoData, IDomainProductService domainProductService)
        {
            guard(title, imageName, description, categoryId, subCategoryId, secondCategoryId, price, slug, seoData,domainProductService);

            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondCategoryId = secondCategoryId;
            Price = price;
            Slug = slug.ToSlug();
            SeoData = seoData;
        }

        public void AddImage(ProductImage image)
        {
            Images.Add(image);
        }
        public void RemoveImage(long imageId)
        {
            var image = Images.FirstOrDefault(c => c.Id == imageId);
            if (image == null)
            {
                throw new InvalidDomainDataException("عکس موجود نیست");
            }

            Images.Remove(image);
        }
        public void SetSpecification(List<ProductSpecification> specification)
        {
            foreach (var productSpecification in specification)
            {
                productSpecification.ProductId = Id;
            }
            Specifications = specification;
        }
    }
}

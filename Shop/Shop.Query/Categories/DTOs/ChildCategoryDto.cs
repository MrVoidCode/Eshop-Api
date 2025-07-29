using Common.Query;
using Shop.Domain.CategoryAgg;
using Shop.Domain.ProductAgg;

namespace Shop.Query.Categories.DTOs;

internal class ChildCategoryDto : BaseDto
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long ProductId { get; private set; }
    public List<Category> Child { get; private set; }
}
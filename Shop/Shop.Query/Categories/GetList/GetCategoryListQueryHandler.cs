using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetList;

internal class GetCategoryListQueryHandler : IBaseQueryHandler<GetCategoryListQuery, List<CategoryDto>>
{
    private readonly ShopContext _context;
    private Mapper _mapper;

    public GetCategoryListQueryHandler(ShopContext context, Mapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.OrderByDescending(f => f.Id).ToListAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}
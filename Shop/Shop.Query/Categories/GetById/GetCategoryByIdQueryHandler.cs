using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetById;

internal class GetCategoryByIdQueryHandler : IBaseQueryHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ShopContext _context;
    private readonly Mapper _mapper;

    public GetCategoryByIdQueryHandler(ShopContext context, Mapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Categories.FirstOrDefaultAsync(f => f.Id == request.CategoryId);
        return _mapper.Map<CategoryDto>(model);
    }
}
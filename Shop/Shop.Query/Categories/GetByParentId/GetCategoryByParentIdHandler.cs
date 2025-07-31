using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories.GetByParentId;

internal class GetCategoryByParentIdHandler : IBaseQueryHandler<GetCategoryByParentId, List<ChildCategoryDto>>
{
    private readonly ShopContext _context;
    private readonly Mapper _mapper;

    public GetCategoryByParentIdHandler(ShopContext context, Mapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ChildCategoryDto>> Handle(GetCategoryByParentId request, CancellationToken cancellationToken)
    {
        var result = await _context.Categories.Where(f => f.Id == request.ParentId).ToListAsync();
        return _mapper.Map<List<ChildCategoryDto>>(result);
    }
}
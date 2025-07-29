using AutoMapper;
using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.Query.Categories.GetByParentId
{
    internal class GetCategoryByParentId : IBaseQuery<List<ChildCategoryDto>>
    {
        public long ParentId { get; set; }
    }
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
}

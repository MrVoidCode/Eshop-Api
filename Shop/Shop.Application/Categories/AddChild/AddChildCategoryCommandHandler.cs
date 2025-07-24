using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.Validation;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.Categories.AddChild
{
    internal class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand>
    {
        private readonly IDomainCategoryRepository _repository;
        private readonly IDomainCategoryService _service;

        public AddChildCategoryCommandHandler(IDomainCategoryRepository repository, IDomainCategoryService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<OperationResult> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            category.AddChild(request.Title, request.Slug, request.SeoData, _service);
            await _repository.Save();
            return OperationResult.Success(); 
        }
    }
}

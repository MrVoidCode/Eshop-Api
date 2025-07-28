using Common.Application;
using Shop.Application.Categories.Create;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Categories.Edit
{
    internal class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryDomainRepository _repository;
        private readonly IDomainCategoryService _service;

        public EditCategoryCommandHandler(ICategoryDomainRepository repository, IDomainCategoryService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetTracking(request.Id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }

            category.Edit(request.Title, request.Slug, request.SeoData, _service);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

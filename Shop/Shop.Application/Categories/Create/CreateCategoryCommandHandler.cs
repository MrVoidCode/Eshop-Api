using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories.Create
{
    internal class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly IDomainCategoryRepository _repository;
        private readonly IDomainCategoryService _service;

        public CreateCategoryCommandHandler(IDomainCategoryRepository repository, IDomainCategoryService service)
        {
            _repository = repository;
            _service = service;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.Title, request.Slug, request.SeoData, _service);
            await _repository.AddAsync(category);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}

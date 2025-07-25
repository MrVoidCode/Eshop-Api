using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Create;

internal class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IDomainProductRepository _productRepository;
    private readonly IDomainProductService _productService;
    private readonly IFileService _fileService;

    public CreateProductCommandHandler(IDomainProductRepository productRepository, IDomainProductService productService)
    {
        _productRepository = productRepository;
        _productService = productService;
    }
    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // save file and generate some ImageName for create (product)
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageName, Directories.ProductImages);
        var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
            request.SubCategoryId, request.SecondCategoryId, request.Price, request.Slug, request.SeoData, _productService);

        await _productRepository.AddAsync(product);

        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        product.SetSpecification(specifications);
        
        await _productRepository.Save();
        return OperationResult.Success();
    }
}
using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.Edit;

internal class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductDomainRepository _productRepository;
    private readonly IDomainProductService _productService;
    private readonly IFileService _fileService;

    public EditProductCommandHandler(IProductDomainRepository productRepository, IDomainProductService productService, IFileService fileService)
    {
        _productRepository = productRepository;
        _productService = productService;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }

        var oldImage = product.ImageName;
        product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
            request.SecondCategoryId, request.Price, request.Slug, request.SeoData, _productService);
        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
            product.SetImage(imageName);
            RemoveOldImage(request.ImageFile, oldImage);
        }

        await _productRepository.AddAsync(product);

        var specifications = new List<ProductSpecification>();
        request.Specifications.ToList().ForEach(specification =>
        {
            specifications.Add(new ProductSpecification(specification.Key, specification.Value));
        });
        await _productRepository.Save();
        return OperationResult.Success();
    }

    private void RemoveOldImage(IFormFile newImage, string oldImage)
    {
        if (newImage != null)
        {
            _fileService.DeleteFile(Directories.ProductImages, oldImage);
        }
    }
}
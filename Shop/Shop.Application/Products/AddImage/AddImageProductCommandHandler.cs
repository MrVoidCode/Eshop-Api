using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Application.Products.AddImage;

internal class AddImageProductCommandHandler : IBaseCommandHandler<AddImageProductCommand>
{
    private readonly IDomainProductRepository _productRepository;
    private readonly IFileService _fileService;

    public AddImageProductCommandHandler(IDomainProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(AddImageProductCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageName, Directories.ProductImagesGallery);
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }
        product.AddImage(new ProductImage(imageName, request.Sequence));
        await _productRepository.Save();
        return OperationResult.Success();
    }
}
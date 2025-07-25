using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.RemoveImage;

internal class RemoveImageProductCommandHandler : IBaseCommandHandler<RemoveImageProductCommand>
{
    private readonly IDomainProductRepository _productRepository;
    private readonly IFileService _fileService;

    public RemoveImageProductCommandHandler(IDomainProductRepository productRepository, IFileService fileService)
    {
        _productRepository = productRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(RemoveImageProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetTracking(request.ProductId);
        if (product == null)
        {
            return OperationResult.NotFound();
        }
        var imageName = product.RemoveImage(request.ImageId);
        _fileService.DeleteFile(Directories.ProductImagesGallery, imageName);
            
        await _productRepository.Save();
        return OperationResult.Success();
    }
}
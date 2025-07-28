using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banner.Edit;

internal class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
{
    private readonly IBannerDomainRepository _repository;
    private readonly IFileService _fileService;

    public EditBannerCommandHandler(IBannerDomainRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.BannerId);
        if (banner == null)
        {
            return OperationResult.NotFound();
        }
        var oldImage = banner.ImageName;
        banner.Edit(request.Link, request.Position);
        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            banner.SetImage(imageName);
            RemoveOldImage(request.ImageFile, oldImage);
        }

        await _repository.Save();

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
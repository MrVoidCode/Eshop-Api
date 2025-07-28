using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Slider.Edit;

internal class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{
    private readonly IDomainSliderRepository _repository;
    private readonly IFileService _fileService;

    public EditSliderCommandHandler(IDomainSliderRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetTracking(request.SliderId);
        if (slider == null)
        {
            return OperationResult.NotFound();
        }
        var oldImage = slider.ImageName;
        slider.Edit(request.Title, request.Link);
        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
            slider.SetImage(imageName);
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
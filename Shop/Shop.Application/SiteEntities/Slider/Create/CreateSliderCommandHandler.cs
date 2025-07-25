using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Slider.Create;

internal class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
{
    private readonly IDomainSliderRepository _repository;
    private readonly IFileService _fileService;
    public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
        var slider = new Domain.SiteEntities.Slider(request.Title, imageName, request.Link);
        await _repository.AddAsync(slider);
        await _repository.Save();

        return OperationResult.Success();
    }
}
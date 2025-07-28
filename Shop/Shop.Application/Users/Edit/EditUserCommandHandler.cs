    using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit;

internal class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
{
    private readonly IUserDomainRepository _userRepository;
    private readonly IDomainUserService _userService;
    private readonly IFileService _fileService;

    public EditUserCommandHandler(IUserDomainRepository userRepository, IDomainUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user == null)
        {
            return OperationResult.NotFound();
        }
        user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender, _userService);
        var oldImage = user.Avatar;
        if (request.ImageFile != null)
        {
            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.AvatarImages);
            user.SetAvatarImage(imageName);
        }

        RemoveOldImage(request.ImageFile, oldImage);
        _userRepository.Add(user);
        await _userRepository.Save();


        return OperationResult.Success();
    }
    private void RemoveOldImage(IFormFile? newImage, string oldImage)
    {
        if (newImage != null)
        {
            _fileService.DeleteFile(Directories.ProductImages, oldImage);
        }
    }
}
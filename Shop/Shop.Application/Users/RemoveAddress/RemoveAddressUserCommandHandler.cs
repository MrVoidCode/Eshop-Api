using Common.Application;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.RemoveAddress;

internal class RemoveAddressUserCommandHandler : IBaseCommandHandler<RemoveAddressUserCommand>
{
    private readonly IUserDomainRepository _userRepository;
    private readonly IDomainUserService _userService;

    public RemoveAddressUserCommandHandler(IUserDomainRepository userRepository, IDomainUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<OperationResult> Handle(RemoveAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user != null)
        {
            return OperationResult.NotFound();
        }
        user.RemoveAddress(request.AddressId);

        await _userRepository.Save();

        return OperationResult.Success();
    }
}
using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.AddAddress;

internal class AddAddressUserCommandHandler : IBaseCommandHandler<AddAddressUserCommand>
{
    private readonly IUserDomainRepository _userRepository;
    private readonly IDomainUserService _userService;

    public AddAddressUserCommandHandler(IUserDomainRepository userRepository, IDomainUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<OperationResult> Handle(AddAddressUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetTracking(request.UserId);
        if (user != null)
        {
            return OperationResult.NotFound();
        }

        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.Name,
            request.LastName, request.PostalAddress, request.PhoneNumber, request.NationalCode);
        user.AddAddress(address);
        await _userRepository.Save();

        return OperationResult.Success();
    }
}
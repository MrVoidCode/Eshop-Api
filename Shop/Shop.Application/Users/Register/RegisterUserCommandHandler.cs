using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Register;

internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserDomainRepository _userRepository;
    private readonly IDomainUserService _userService;

    public RegisterUserCommandHandler(IUserDomainRepository userRepository, IDomainUserService userService)
    {
        _userRepository = userRepository;
        _userService = userService;
    }
    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber, request.Password, _userService);
        _userRepository.Add(user);
        _userRepository.Save();
        return OperationResult.Success();
    }
}
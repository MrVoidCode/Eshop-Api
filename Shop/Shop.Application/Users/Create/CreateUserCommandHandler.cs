using Common.Application;
using Common.Application.SecurityUtil;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Create;

internal class CreateUserCommandHandler : IBaseCommandHandler<CreateUserCommand>
{
    private readonly IUserDomainRepository _repository;
    private readonly IDomainUserService _service;

    public CreateUserCommandHandler(IUserDomainRepository repository, IDomainUserService service)
    {
        _repository = repository;
        _service = service;
    }
    public async Task<OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var password = Sha256Hasher.Hash(request.Password);
        var user = new User(request.Name, request.Family, request.PhoneNumber, password, request.Email,
            request.Gender, _service);
        _repository.Add(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}
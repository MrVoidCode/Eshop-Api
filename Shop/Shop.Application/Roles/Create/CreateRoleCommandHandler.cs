using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Create;

internal class CreateRoleCommandHandler : IBaseCommandHandler<CreateRoleCommand>
{
    private readonly IRoleDomainRepository _repository;

    public CreateRoleCommandHandler(IRoleDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var rolePermissions = new List<RolePermission>();
        request.Permissions.ForEach(permission =>
        {
            rolePermissions.Add(new RolePermission(permission));
        });

        var role = new Role(request.Title, rolePermissions);
        await _repository.AddAsync(role);
        await _repository.Save();
        return OperationResult.Success();
    }
}
using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;

namespace Shop.Application.Roles.Edit;

internal class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
{
    private readonly IRoleDomainRepository _repository;

    public EditRoleCommandHandler(IRoleDomainRepository repository)
    {
        _repository = repository;
    }
    public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _repository.GetTracking(request.RoleId);
        if (role == null)
        { 
            return OperationResult.NotFound();
        }
        role.Edit(request.Title);

        if (request.Permissions != null)
        {
            var rolePermissions = new List<RolePermission>();
            request.Permissions.ForEach(permission =>
            {
                rolePermissions.Add(new RolePermission(permission));
            });
            role.SetPermission(rolePermissions);
        }
            
        await _repository.Save();
        return OperationResult.Success();
    }
}
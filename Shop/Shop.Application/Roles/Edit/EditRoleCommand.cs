using Common.Application;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommand : IBaseCommand
    {
        public EditRoleCommand(long roleId, string title, List<Permission>? permissions)
        {
            RoleId = roleId;
            Title = title;
            Permissions = permissions;
        }
        public long RoleId { get; private set; }
        public string Title { get; private set; }
        public List<Permission>? Permissions { get; private set; }
    }
}

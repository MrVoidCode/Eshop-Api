using Common.Application;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Roles.Create
{
    internal class CreateRoleCommand : IBaseCommand
    {
        public CreateRoleCommand(string title, List<Permission> permissions)
        {
            Title = title;
            Permissions = permissions;
        }
        public long RoleId { get; private set; }
        public string Title { get; private set; }
        public List<Permission> Permissions { get; private set; }
    }
}

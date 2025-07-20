using Shop.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.RoleAgg
{
    public class RolePermission
    {
        public long RoleId { get; internal set; }
        public Permission Permission { get; private set; }
    }
}

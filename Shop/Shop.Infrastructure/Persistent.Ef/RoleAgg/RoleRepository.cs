using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.RoleAgg
{
    internal class RoleRepository : BaseRepository<Role>, IRoleDomainRepository
    {
        public RoleRepository(ShopContext context) : base(context)
        {
        }
    }
}

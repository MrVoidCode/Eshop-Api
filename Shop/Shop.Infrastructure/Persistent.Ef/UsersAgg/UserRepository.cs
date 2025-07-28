using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.UsersAgg
{
    internal class UserRepository : BaseRepository<User>, IUserDomainRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {
        }

        public async Task<UserAddress> GetUserAddressById(long addressId)
        {
            throw new NotImplementedException();
        }
    }
}

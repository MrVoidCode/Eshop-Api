using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg
{
    internal class OrderRepository : BaseRepository<Order>, IOrderDomainRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {
        }

        public async Task<Order> GetCurrentOrderById(long userId)
        {
            throw new NotImplementedException();
        }
    }
}

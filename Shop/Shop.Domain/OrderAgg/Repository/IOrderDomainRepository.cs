using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.OrderAgg.Repository
{
    public interface IOrderDomainRepository : IBaseRepository<Order>
    {
        Task<Order> GetCurrentOrderById(long userId);
    }
}

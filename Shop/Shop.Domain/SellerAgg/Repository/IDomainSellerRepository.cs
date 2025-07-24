using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Repository;

namespace Shop.Domain.SellerAgg.Repository
{
    public interface IDomainSellerRepository : IBaseRepository<Seller>
    {
        Task<InventoryResult> GetInventoryById(long inventoryId);

    }

    public class InventoryResult
    {
        public long InventoryId { get;  set; }
        public long SellerId { get;  set; }
        public long ProductId { get;  set; }
        public int Count { get;  set; }
        public int Price { get;  set; }
    }
}

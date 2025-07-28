using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg
{
    internal class SellerRepository : BaseRepository<Seller>, ISellerDomainRepository
    {
        public SellerRepository(ShopContext context) : base(context)
        {
        }

        public async Task<InventoryResult> GetInventoryById(long inventoryId)
        {
            throw new NotImplementedException();
        }
    }
}

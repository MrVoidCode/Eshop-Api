using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductDomainRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {
        }
    }
}

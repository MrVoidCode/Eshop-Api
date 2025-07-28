using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.CategoryAgg;
using Shop.Domain.CategoryAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryDomainRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {
        }
    }
}

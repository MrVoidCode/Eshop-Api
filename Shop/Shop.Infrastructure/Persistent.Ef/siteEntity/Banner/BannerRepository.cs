using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.siteEntity.Banner
{
    internal class BannerRepository : BaseRepository<Domain.SiteEntities.Banner>, IBannerDomainRepository
    {
        public BannerRepository(ShopContext context) : base(context)
        {
        }
    }
}

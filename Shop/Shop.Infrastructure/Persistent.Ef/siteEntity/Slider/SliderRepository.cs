using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.SiteEntities.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.siteEntity.Slider
{
    internal class SliderRepository : BaseRepository<Domain.SiteEntities.Slider>, ISliderDomainRepository
    {
        public SliderRepository(ShopContext context) : base(context)
        {
        }
    }
}

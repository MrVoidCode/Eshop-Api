using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg.Services
{
    internal interface IDomainProductService
    {
        bool SlugIsExist(string slug);
    }
}

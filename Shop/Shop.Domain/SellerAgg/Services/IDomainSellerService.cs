using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.SellerAgg.Services
{
    public interface IDomainSellerService
    {
        bool UserIdIsExistInDataBase(long userId);
        bool NationalCodeExistInDataBase(string nationalCode);
    }
}

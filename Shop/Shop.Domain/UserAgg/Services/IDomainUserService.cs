using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg.Services
{
    internal interface IDomainUserService
    {
        bool IsEmailExist(string email);
        bool IsPhoneExist(string phone);

    }
}

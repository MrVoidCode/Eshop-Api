using Common.Application;
using Common.Domain.ValueObjects;
using Shop.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.RemoveAddress
{
    internal class RemoveAddressUserCommand : IBaseCommand
    {
        public RemoveAddressUserCommand(long userId, long addressId)
        {
            UserId = userId;
            AddressId = addressId;
        }
        public long UserId { get; internal set; }
        public long AddressId { get; internal set; }
    }
}

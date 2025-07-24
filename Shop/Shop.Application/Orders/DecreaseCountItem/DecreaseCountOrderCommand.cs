using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Application.Validation;

namespace Shop.Application.Orders.DecreaseCount
{
    internal class DecreaseCountOrderCommand : IBaseCommand
    {
        public DecreaseCountOrderCommand(long userId, long itemId, int count)
        {
            UserId = userId;
            ItemId = itemId;
        }

        public long UserId { get; private set; }
        public long ItemId { get; private set; }
        public int Count { get; private set; }
    }
}

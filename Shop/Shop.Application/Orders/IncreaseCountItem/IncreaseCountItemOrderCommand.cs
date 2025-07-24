using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.IncreaseCountItem
{
    internal class IncreaseCountItemOrderCommand : IBaseCommand
    {
        public IncreaseCountItemOrderCommand(long userId, long itemId, int count)
        {
            UserId = userId;
            ItemId = itemId;
            Count = count;
        }
        public long UserId { get; private set; }
        public long ItemId { get; private set; }
        public int Count { get; private set; }
    }
}

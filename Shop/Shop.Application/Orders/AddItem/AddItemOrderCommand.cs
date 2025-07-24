using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;

namespace Shop.Application.Orders.AddItem
{
    public class AddItemOrderCommand : IBaseCommand
    {
        public AddItemOrderCommand(long inventoryId,long userId, int price, int count)
        {
            InventoryId = inventoryId;
            Price = price;
            Count = count;
        }
        public long UserId { get; private set; }
        public long InventoryId { get; private set; }
        public int Price { get; private set; }
        public int Count { get; private set; }
    }
}

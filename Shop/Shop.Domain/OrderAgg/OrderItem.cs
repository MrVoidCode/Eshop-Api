using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.OrderAgg
{
    internal class OrderItem : BaseEntity
    {
        public OrderItem(long inventoryId, int price, int count)
        {
            PriceGuard(price);
            CountGuard(count);
            InventoryId = inventoryId;
            Price = price;
            Count = count;
        }
        public long OrderId { get; private set; }
        public long InventoryId { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Count * Price;
        public int Count { get; private set; }

        public void PriceGuard(int newPrice)
        {

            if (newPrice < 0)
            {
                throw new InvalidDomainDataException();
            }
        }
        public void CountGuard(int newCount)
        {
            if (newCount < 0)
            {
                throw new InvalidDomainDataException();
            }
        }


        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);

            Count = newCount;
        }

        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }
    }
}

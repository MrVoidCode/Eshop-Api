using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg
{
    public class SellerInventory : BaseEntity
    {
        public SellerInventory(int count, int price)
        {
            if (count < 0 || price < 0)
            {
                throw new InvalidDomainDataException();
            }
            Count = count;
            Price = price;
        }
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public bool IsActive { get; private set; }
    }
}

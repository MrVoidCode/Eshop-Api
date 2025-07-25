using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace Shop.Application.Sellers.DeleteInventory
{
    public class DeleteInventorySellerCommand : IBaseCommand
    {
        public DeleteInventorySellerCommand(long sellerId, long productId)
        {
            SellerId = sellerId;
            ProductId = productId;
        }
        public long SellerId { get; internal set; }
        public long ProductId { get; private set; }
    }
}

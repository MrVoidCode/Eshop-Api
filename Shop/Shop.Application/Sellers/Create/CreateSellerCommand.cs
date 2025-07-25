using Common.Application;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Shop.Domain.SellerAgg;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommand : IBaseCommand
    {
        public CreateSellerCommand(long userId, string shopName, string nationalCode, SellerStatus status)
        {
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            Status = status;
        }
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        
    }
}

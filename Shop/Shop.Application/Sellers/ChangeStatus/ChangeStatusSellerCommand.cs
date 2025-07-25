using AngleSharp.Io;
using Common.Application;
using Shop.Domain.SellerAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Sellers.ChangeStatus
{
    internal class ChangeStatusSellerCommand : IBaseCommand
    {
        public ChangeStatusSellerCommand(SellerStatus status)
        {
            Status = status;
        }
        public long SellerId { get; internal set; }
        public SellerStatus Status { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using FluentValidation;

namespace Shop.Application.Orders.RemoveItem
{
    internal class RemoveItemOrderCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public long ItemId { get; private set; }
    }
}

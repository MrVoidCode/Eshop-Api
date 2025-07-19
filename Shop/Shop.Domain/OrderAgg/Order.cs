using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Services;
using Shop.Domain.UserAgg;

namespace Shop.Domain.OrderAgg
{
    internal class Order : AggregateRoot
    {
        private Order()
        {
        }
        public Order(long userId)
        {
            UserId = userId;
            Status = OrderStatus.Pending;
            Items = new List<OrderItem>();
        }
        public long UserId { get; internal set; }
        public int TotalPrice
        {
            get
            {
                var TotalPrice = Items.Sum(c => c.Price);
                if (ShippingMethod != null)
                {
                    TotalPrice += ShippingMethod.ShippingCost;
                }
                if (Discount != null)
                {
                    TotalPrice += Discount.Amount;
                }

                return TotalPrice;
            }
        }
        public int ItemCount => Items.Count;
        public OrderStatus Status { get; private set; }
        public Discount? Discount { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public ShippingMethod? ShippingMethod { get; private set; }
        public OrderAddress? Address { get; private set; }
        public List<OrderItem> Items { get; private set; }


        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(long orderItemId)
        {
            var oldOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (oldOrder != null)
            {
                Items.Remove(oldOrder);
            }

            
        }
        public void ChangeCountItem(long orderItemId, int newCount)
        {
            var currentOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (currentOrder != null)
            {
                currentOrder.ChangeCount(newCount);
            }
        }

        public void EditItem(long orderItemId, OrderItem orderItem)
        {
            var oldOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (oldOrder != null)
            {
                Items.Remove(oldOrder);
                Items.Add(orderItem);
                LastUpdateDate = DateTime.Now;
            }
        }
        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
            LastUpdateDate = DateTime.Now;
        }
        public void AddDiscount(Discount discount)
        {
            Discount = discount;
        }

        public void Checkout(OrderAddress address)
        {
            Address = address;

        }
    }

    internal class ShippingMethod : BaseValueObject
    {
        public string ShippingTitle { get; private set; }
        public int ShippingCost { get; private set; }
    }
}

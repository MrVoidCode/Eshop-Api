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
    public class Order : AggregateRoot
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

        public void ChangeOrderGuard()
        {
            if (Status != OrderStatus.Pending)
            {
                throw new InvalidDomainDataException("امکان تغییر محصول در این سفارش وجود ندارد");
            }
        }

        public void AddItem(OrderItem item)
        {
            ChangeOrderGuard();
            var oldItem = Items.FirstOrDefault(c => c.InventoryId == item.InventoryId);
            if (oldItem != null)
            {
                oldItem.ChangeCount(oldItem.Count + ItemCount);
                return;
            }

            Items.Add(item);
        }

        public void RemoveItem(long orderItemId)
        {
            ChangeOrderGuard();
            var oldOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (oldOrder != null)
            {
                Items.Remove(oldOrder);
            }
        }

        public void ChangeCountItem(long orderItemId, int newCount)
        {
            ChangeOrderGuard();
            var currentOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (currentOrder != null)
            {
                currentOrder.ChangeCount(newCount);
            }
        }
        public void DecreaseCountItem(long orderItemId, int newCount)
        {
            ChangeOrderGuard();
            var currentOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (currentOrder != null)
            {
                currentOrder.DecreaseCount(newCount);
            }
        }
        public void IncreaseCountItem(long orderItemId, int newCount)
        {
            ChangeOrderGuard();
            var currentOrder = Items.FirstOrDefault(c => c.Id == orderItemId);
            if (currentOrder != null)
            {
                currentOrder.IncreaseCount(newCount);
            }
        }

        public void EditItem(long orderItemId, OrderItem orderItem)
        {
            ChangeOrderGuard();
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
            ChangeOrderGuard();
            Discount = discount;
        }

        public void Checkout(OrderAddress address)
        {
            ChangeOrderGuard();
            Address = address;

        }
    }
}

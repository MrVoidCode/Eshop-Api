using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;

namespace Shop.Domain.SellerAgg
{
    internal class Seller : AggregateRoot
    {
        public Seller(string shopName, string nationalCode, SellerStatus status)
        {
            Guard(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime LastUpdate { get; internal set; }
        public List<InventoryItem> InventoryItems { get; private set; }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            {
                throw new InvalidDomainDataException("کد ملی وارد شده نامعتبر است");
            }
        }

        public void Edit(string shopName, string nationalCode, SellerStatus status)
        {
            Guard(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
            LastUpdate = DateTime.Now;
        }

        public void AddInventory(InventoryItem newInventoryItem)
        {
            if (InventoryItems.Any(c => c.ProductId == newInventoryItem.ProductId))
            {
                throw new InvalidDomainDataException("کالا در موجودی شما وجود دارد");

            }
            InventoryItems.Add(newInventoryItem);
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void EditInventory(long productId, InventoryItem newInventoryItem)
        {
            var oldInventoryItem = InventoryItems.FirstOrDefault(c => c.ProductId == productId);
            if (oldInventoryItem == null)
            {
                throw new InvalidDomainDataException("کالا وارد شده موجود نمی باشد");
            }
            InventoryItems.Remove(oldInventoryItem);
            InventoryItems.Add(newInventoryItem);
        }
        public void DeleteInventory(long productId)
        {
            var InventoryItem = InventoryItems.FirstOrDefault(c => c.ProductId == productId);
            if (InventoryItem == null)
            {
                throw new InvalidDomainDataException("کالا وارد شده موجود نمی باشد");
            }
            InventoryItems.Remove(InventoryItem);
        }

    }
}

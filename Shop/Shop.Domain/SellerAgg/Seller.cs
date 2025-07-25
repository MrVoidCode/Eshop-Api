using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        public Seller(long userId, string shopName, string nationalCode, IDomainSellerService domainSellerService)
        {
            UserIdDuplicateSellerChecker(userId, domainSellerService);
            NationalCodeDuplicateSellerChecker(nationalCode, domainSellerService);
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
        }
        public long UserId { get; private set; }
        public string ShopName { get; private set; }
        public string NationalCode { get; private set; }
        public SellerStatus Status { get; private set; }
        public DateTime LastUpdate { get; internal set; }
        public List<SellerInventory> SellerInventoryItems { get; private set; }

        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString(shopName, nameof(shopName));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));
            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
            {
                throw new InvalidDomainDataException("کد ملی وارد شده نامعتبر است");
            }
        }

        public void UserIdDuplicateSellerChecker(long userId, IDomainSellerService domainSellerService)
        {
            if (UserId != userId)
            {
                if (domainSellerService.UserIdIsExistInDataBase(userId))
                {
                    throw new InvalidDomainDataException("اطلاعات نا معتبر است");
                }
            }
        }
        public void NationalCodeDuplicateSellerChecker(string nationalCode, IDomainSellerService domainSellerService)
        {
            if (NationalCode != nationalCode)
            {
                if (domainSellerService.NationalCodeExistInDataBase(nationalCode))
                {
                    throw new InvalidDomainDataException("این کد ملی متعلق به شخصی دیگر است");
                }
            }
        }

        public void Edit(string shopName, string nationalCode, IDomainSellerService domainSellerService)
        {
            NationalCodeDuplicateSellerChecker(nationalCode, domainSellerService);
            Guard(shopName, nationalCode);
            ShopName = shopName;
            NationalCode = nationalCode;
            LastUpdate = DateTime.Now;
        }

        public void AddInventory(SellerInventory newInventoryItem)
        {
            if (SellerInventoryItems.Any(c => c.ProductId == newInventoryItem.ProductId))
            {
                throw new InvalidDomainDataException("کالا در موجودی شما وجود دارد");

            }
            SellerInventoryItems.Add(newInventoryItem);
        }

        public void ChangeStatus(SellerStatus status)
        {
            Status = status;
            LastUpdate = DateTime.Now;
        }

        public void EditInventory(long inventoryId, int count, int price, int? discountPercentage)
        {
            var currentInventory = SellerInventoryItems.FirstOrDefault(c => c.Id == inventoryId);
            if (currentInventory == null)
            {
                throw new InvalidDomainDataException("کالا وارد شده موجود نمی باشد");
            }
            currentInventory.Edit(count, price, discountPercentage);
        }
        public void DeleteInventory(long inventoryId)
        {
            var inventoryItem = SellerInventoryItems.FirstOrDefault(c => c.Id == inventoryId);
            if (inventoryItem == null)
            {
                throw new InvalidDomainDataException("کالا وارد شده موجود نمی باشد");
            }
            SellerInventoryItems.Remove(inventoryItem);
        }

    }
}

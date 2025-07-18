using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    internal class User : AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string password, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;

        }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; set; }
        public List<UserRole> Roles { get; set; }
        public List<Wallet> Wallets { get; set; }

        public void Guard(string phoneNumber, string email, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
            {
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
            }
            if (email.IsValidEmail() == false)
            {
                throw new InvalidDomainDataException("ایمیل نامعتبر است");
            }
            if (PhoneNumber != phoneNumber)
            {
                if (domainService.IsPhoneExist(phoneNumber))
                {
                    throw new InvalidDomainDataException("شماره تکراری موبایل تکراری میباشد");
                }
            }

            if (email != Email)
            {
                if (domainService.IsEmailExist(email))
                {
                    throw new InvalidDomainDataException("شماره تکراری ایمیل تکراری میباشد");
                }
            }
        }

        public static User RegisterUser(string phoneNumber, string email, string password, IDomainUserService domainService)
        {
            return new User("", "", phoneNumber, password, email, Gender.None, domainService);
        }

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, string avatar, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;

            Email = email;
            Gender = gender;
        }
        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);

        }

        public void RemoveAddress(long addressId)
        {
            var address = Addresses.FirstOrDefault(a => a.Id == addressId);
            if (address == null)
            {
                throw new InvalidDomainDataException("address not found");
            }

            Addresses.Remove(address);
        }

        public void ChargeWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }
        public void SetRole(List<UserRole> roles)
        {
            foreach (var item in roles)
            {
                item.UserId = Id;
            }
            Roles.Clear();
            Roles.AddRange(roles);
        }

    }
}

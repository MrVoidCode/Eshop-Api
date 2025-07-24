using Common.Application;
using Shop.Domain.OrderAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Orders.Checkout
{
    internal class CheckoutOrderCommand : IBaseCommand
    {
        public CheckoutOrderCommand(long userId, string shire, string city, string postalCode,
            string name, string lastName, string postalAddress, string phoneNumber, string nationalCode, Order order)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            LastName = lastName;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            Order = order;
        }
        public long UserId { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public Order Order { get; set; }
    }
}

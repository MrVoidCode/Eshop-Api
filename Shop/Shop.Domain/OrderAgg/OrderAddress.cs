using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.OrderAgg
{
    internal class OrderAddress
    {
        public OrderAddress(string shire, string city, string postalCode, string fullname, string postalAddress, string phoneNumber, string nationalCode)
        {
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Fullname = fullname;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
        public long OrderId { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Fullname { get; private set; }
        public string PostalAddress { get; private set; }
        public string PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
        public Order Order { get; set; }
    }
}

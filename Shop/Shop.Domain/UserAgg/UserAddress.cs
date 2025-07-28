using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System.Xml.Linq;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string shire, string city, string postalCode,
        string name, string lastName, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
    {
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        Name = name;
        LastName = lastName;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
        ActiveAddress = false;
    }
    public long UserId { get; internal set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string PostalAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }

    public void Guard(string shire, string city, string postalCode,PhoneNumber phoneNumber , string name, string lastName, string postalAddress,
        string nationalCode)
    {
        if (phoneNumber == null)
        {
            throw new InvalidDomainDataException("شماره تلفن نمیتواند خالی باشد");
        }
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(name, nameof(name));
        NullOrEmptyDomainDataException.CheckString(lastName, nameof(lastName));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
        {
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }

    public void Edit(string shire, string city, string postalCode,
        string name, string lastName, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
    {
        Guard(shire, city, postalCode, phoneNumber, name, lastName, postalAddress, nationalCode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        Name = name;
        LastName = lastName;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }
}
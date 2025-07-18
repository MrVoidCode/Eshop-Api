using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class UserAddress : BaseEntity
{
    public UserAddress(string shire, string city, string postalCode, string fullname, string postalAddress, string phoneNumber, string nationalCode)
    {
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        Fullname = fullname;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode =nationalCode;
        ActiveAddress = false;
    }
    public long UserId { get; internal set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Fullname { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string NationalCode { get; private set; }
    public bool ActiveAddress { get; private set; }

    public void Guard(string shire, string city, string postalCode, string fullname, string postalAddress, string phoneNumber,
        string nationalCode)
    {
        NullOrEmptyDomainDataException.CheckString(shire, nameof(shire));
        NullOrEmptyDomainDataException.CheckString(city, nameof(city));
        NullOrEmptyDomainDataException.CheckString(postalCode, nameof(postalCode));
        NullOrEmptyDomainDataException.CheckString(fullname, nameof(fullname));
        NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(postalAddress));
        NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
        NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(nationalCode));

        if (IranianNationalIdChecker.IsValid(nationalCode) == false)
        {
            throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }
    }

    public void Edit(string shire, string city, string postalCode, string fullname, string postalAddress,
        string phoneNumber, string nationalCode, bool activeAddress)
    {
        Guard(shire, city, postalCode, fullname, postalAddress, phoneNumber, nationalCode);
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        Fullname = fullname;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        NationalCode = nationalCode;
    }

    public void SetActive()
    {
        ActiveAddress = true;
    }
}
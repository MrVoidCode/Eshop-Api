using Common.Application;
using Common.Domain.ValueObjects;
using FluentValidation;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.UserAgg;

namespace Shop.Application.Users.EditAddress
{
    internal class EditAddressUserCommand : IBaseCommand
    {
        public EditAddressUserCommand(long addressId, long userId, string shire, string city, string postalCode, string name, string lastName, string postalAddress, PhoneNumber phoneNumber, string nationalCode)
        {
            AddressId = addressId;
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            LastName = lastName;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
        }
        public long AddressId { get; internal set; }
        public long UserId { get; internal set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
    }

    internal class EditAddressUserCommandHandler : IBaseCommandHandler<EditAddressUserCommand>
    {
        private readonly IUserDomainRepository _repository;
        private readonly IDomainUserService _service;

        public EditAddressUserCommandHandler(IUserDomainRepository repository, IDomainUserService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task<OperationResult> Handle(EditAddressUserCommand request, CancellationToken cancellationToken)
        {
            var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.Name,
                request.LastName
                , request.PostalAddress, request.PhoneNumber, request.NationalCode);
            var user = await _repository.GetTracking(request.UserId);
            if (address == null)
            {
                return OperationResult.NotFound();
            }
            user.EditAddress(request.AddressId, address);
            return OperationResult.Success();
        }
    }
    internal class EditAddressUserCommandValidation : AbstractValidator<EditAddressUserCommand>
    {
    }
}

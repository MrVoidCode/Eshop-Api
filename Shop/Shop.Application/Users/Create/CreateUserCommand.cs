using Common.Application;
using Shop.Domain.UserAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Domain.SellerAgg.Repository;

namespace Shop.Application.Users.Create
{
    internal class CreateUserCommand : IBaseCommand
    {
        public CreateUserCommand(string name, string family, string phoneNumber, string password, string email, Gender gender)
        {
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
    }
}
